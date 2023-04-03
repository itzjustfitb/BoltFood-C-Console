
using BoltFood.Service.Implementations;
using BoltFood.Service.Interfaces;

IMenuService menuService=new MenuService();
await menuService.ShowMenuAsync();