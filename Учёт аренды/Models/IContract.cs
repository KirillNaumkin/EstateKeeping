using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IContract
    {
        public DateTime AgreementDate { get; set; }
        public string Number { get; set; }
        public IRoom Object { get; set; }
        public ISubject RentGiver { get; set; }
        public ISubject RentHolder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalFee { get; set; }
        public string RentPurpose { get; set; }
        public IAccount Account { get; set; }
        public string Comment { get; set; }
        public byte PayDay { get; set; }
        public IEnumerable<IBilling> Billings { get; set; }
    }
}
