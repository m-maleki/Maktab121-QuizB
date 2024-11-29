namespace QuizB.Entities;
public class Transaction
{
    #region Properties
    public int Id { get; set; }
    public int SourceCardId { get; set; }
    public int DestinationCardId { get; set; }
    public DateTime ActionAt { get; set; }
    public float Amount { get; set; }
    public bool IsSuccess { get; set; }
    #endregion

    #region NavigationProperties
    public Card SourceCard { get; set; }
    public Card DestinationCard { get; set; }
    #endregion
}