﻿namespace OnlineBanking.Application.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}