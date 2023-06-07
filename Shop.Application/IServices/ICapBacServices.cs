﻿using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ICapBacServices
{
    Task<Guid> Create(CapBacVM cb);
    Task<Guid> Edit(CapBacVM kh);
    Task<int> Delete(Guid id);
    Task<List<CapBacVM>> GetAll();
    Task<CapBacVM> GetById(Guid id);
}