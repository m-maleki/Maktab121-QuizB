﻿namespace QuizB.Entities;
public class Card
{
    #region Properties
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string HolderName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; } = true;
    public float Balance { get; set; } = 0;
    public int WrongPasswordTries { get; set; } = 0;
    public int UserId { get; set; }
    public string CVV2 { get; set; }
    #endregion

    #region NavigationProperties
    public List<Transaction> TransactionsAsSource { get; set; }
    public List<Transaction> TransactionsAsDestination { get; set; }
    public User User { get; set; }
    #endregion
}