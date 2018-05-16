﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Models.ApplicationUserViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Title { get; set; }

        public string CabinetAdress { get; set; }
    }
}
