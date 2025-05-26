<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;

=======
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
namespace PullCourse.Models;

public class Course
{
<<<<<<< HEAD
    [Column("currency_code")]
    public string CurrencyCode { get; set; }

    [Column("buy_rate")]
    public double Buy { get; set; }

    [Column("sell_rate")]
    public double Sell { get; set; }

    [Column("city")]
    public string City { get; set; }
}
=======
    public string CurrencyCode { get; set; }
    public decimal Buy { get; set; }
    public decimal Sell { get; set; }
}
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
