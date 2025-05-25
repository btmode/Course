using System.ComponentModel.DataAnnotations.Schema;

namespace PullCourse.Models;

public class Course
{
    [Column("currency_code")]
    public string CurrencyCode { get; set; }

    [Column("buy_rate")]
    public double Buy { get; set; }

    [Column("sell_rate")]
    public double Sell { get; set; }

    [Column("city")]
    public string City { get; set; }
}
