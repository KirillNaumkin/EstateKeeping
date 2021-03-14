using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IContract
    {
        DateTime AgreementDate { get; set; }
        string Number { get; set; }
        IRoom Object { get; set; }
        ISubject RentGiver { get; set; }
        ISubject RentHolder { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        decimal RentalFee { get; set; }
        string RentPurpose { get; set; }
        IAccount Account { get; set; }
        string Comment { get; set; }
        byte PayDay { get; set; }
        IEnumerable<IBilling> Billings { get; set; }
    }
}
