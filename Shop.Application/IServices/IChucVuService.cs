﻿using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IChucVuService
    {
        Task<List<ChucVuVM>> GetAllChucVu();
    }
}
