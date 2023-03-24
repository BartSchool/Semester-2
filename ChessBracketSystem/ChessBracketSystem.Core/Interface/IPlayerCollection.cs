﻿namespace ChessBracketSystem.Core.Interface;

public interface IPlayerCollection
{
    IReadOnlyList<IPlayer> List { get; }

    void Add(IPlayer player);
    void Add(List<IPlayer> playerList);
    void Remove(IPlayer player);
    void Remove(List<IPlayer> playerList);
}