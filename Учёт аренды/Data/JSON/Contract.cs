using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Contract : DbRecord, IContract
    {
        public DateTime AgreementDate { get; set; }
        public string Number { get; set; }
        public string RoomID { get; set; }
        public IRoom Object { get; set; }
        public string RentGiverID { get; set; }
        public ISubject RentGiver { get; set; }
        public string RentHolderID { get; set; }
        public ISubject RentHolder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalFee { get; set; }
        public string RentPurpose { get; set; }
        public string AccountID { get; set; }
        public IAccount Account { get; set; }
        public string Comment { get; set; }
        public byte PayDay { get; set; }
        public IEnumerable<IBilling> Billings { get; set; }
    }
}
