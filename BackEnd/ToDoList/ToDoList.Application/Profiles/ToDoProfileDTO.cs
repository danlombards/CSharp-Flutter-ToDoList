using ToDoList.Application.Models.ToDo;
using ToDoList.Application.Models;
using AutoMapper;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Profiles
{
    public class ToDoProfileDTO : Profile
    {
        public ToDoProfileDTO()
        {
            CreateMap<BaseEntity, BaseEntityDTO>().ReverseMap();
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
            CreateMap<ToDo, CreateToDoDTO>().ReverseMap();
        }
    }
}
