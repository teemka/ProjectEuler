﻿namespace ProjectEuler;

public interface IProblem
{
    Task<string> CalculateAsync(string[] args);
}
