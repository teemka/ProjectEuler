namespace ProjectEuler.Problems._101_200._181_190;

/// <summary>
/// https://projecteuler.net/problem=186
/// Answer: 2325629
/// </summary>
public class Problem186 : IProblem
{
    private static readonly Dictionary<int, int> Prev = new();

    public static int GetCallerNo(int n) => LaggedFibonacciGenerator((2 * n) - 1);

    public static int GetCalledNo(int n) => LaggedFibonacciGenerator(2 * n);

    public static int LaggedFibonacciGenerator(int k)
    {
        if (k <= 55)
        {
            var value = (100003 - (200003 * k) + (300007 * (long)Math.Pow(k, 3))) % 1000000;

            Prev[k] = (int)value;
        }
        else
        {
            Prev[k] = (Prev[k - 24] + Prev[k - 55]) % 1000000;
        }

        return Prev[k];
    }

    public Task<string> CalculateAsync(string[] args)
    {
        var usersByNumbers = new Dictionary<int, NetworkUser>();
        var pm = GetUser(524287);
        HashSet<NetworkUser>? pmsNetwork = null;

        NetworkUser GetUser(int number)
        {
            if (!usersByNumbers.ContainsKey(number))
            {
                usersByNumbers[number] = new NetworkUser(number);
            }

            return usersByNumbers[number];
        }

        int count = 0;
        int n = 0;
        while (true)
        {
            n++;
            var callerNo = GetCallerNo(n);
            var calledNo = GetCalledNo(n);

            if (callerNo == calledNo)
            {
                // misdiall - skip
                continue;
            }

            count++;
            var caller = GetUser(callerNo);
            var called = GetUser(calledNo);

            if (pmsNetwork is null && (caller == pm || called == pm))
            {
                // Build the PMs network of friends
                caller.Friends.Add(called);
                called.Friends.Add(caller);
                pmsNetwork = ExploreNetwork(pm);
            }

            if (pmsNetwork is not null)
            {
                var isCalledInNetwork = pmsNetwork.Contains(called);
                var isCallerInNetwork = pmsNetwork.Contains(caller);

                if (isCalledInNetwork == isCallerInNetwork)
                {
                    // Do nothing - call does not connect the PMs network with any other network
                }
                else if (isCallerInNetwork)
                {
                    // Caller in the PMs network calls someone outside the network.
                    // Merge the called's network with PMs network.
                    var calledsNetwork = ExploreNetwork(called);
                    foreach (var user in calledsNetwork)
                    {
                        pmsNetwork.Add(user);
                    }
                }
                else if (isCalledInNetwork)
                {
                    // Caller outside the PMs network calls someone inside the PMs network.
                    // Merge the caller's network with PMs network.
                    var callersNetwork = ExploreNetwork(caller);
                    foreach (var user in callersNetwork)
                    {
                        pmsNetwork.Add(user);
                    }
                }

                var percentage = pmsNetwork.Count / 1_000_000D;
                if (percentage >= 0.99)
                {
                    break;
                }
            }

            caller.Friends.Add(called);
            called.Friends.Add(caller);
        }

        return Task.FromResult(count.ToString());
    }

    /// <summary>
    /// Perform a breadth first exploration of the graph.
    /// </summary>
    /// <remarks>
    /// https://en.wikipedia.org/wiki/Breadth-first_search
    /// </remarks>
    private static HashSet<NetworkUser> ExploreNetwork(NetworkUser root)
    {
        var explored = new HashSet<NetworkUser> { root };
        var queue = new Queue<NetworkUser>();
        queue.Enqueue(root);

        while (queue.TryDequeue(out var user))
        {
            foreach (var friend in user.Friends)
            {
                if (!explored.Contains(friend))
                {
                    explored.Add(friend);
                    queue.Enqueue(friend);
                }
            }
        }

        return explored;
    }

    public class NetworkUser
    {
        public NetworkUser(int number)
        {
            this.Number = number;
        }

        public int Number { get; }

        public HashSet<NetworkUser> Friends { get; } = new();

        public override string ToString() => this.Number.ToString();
    }
}
