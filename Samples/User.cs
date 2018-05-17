using System;
using System.Collections.Generic;
using System.Text;

namespace Samples
{
    class User
    {
        public string Name { get; set; }
        public string AccountNum { get; set; }
        public string Company { get; set; }
        public decimal Fee { get; set; }

        public User(string name, string accountNum, string company, decimal fee)
        {
            Name = name;
            AccountNum = accountNum;
            Company = company;
            Fee = fee;
        }

        public override string ToString()
        {
            return String.Format("User: {0,-15} Account#: {1,-8} with {2,-18} Fee: {3:C}", Name, AccountNum, Company, Fee);
        }
    }
}
