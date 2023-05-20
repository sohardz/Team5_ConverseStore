﻿using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ViewModels
{
    public class GiamGiaVM
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int MucGiamGiaPhanTram { get; set; }
        public decimal MucGiamGiaTienMat { get; set; }
        public string DieuKienGiamGia { get; set; }
        public int LoaiGiamGia { get; set; }
        public int TrangThai { get; set; }

    }
}