using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.ToDo;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

namespace ToDoList.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ToDoDTO CreateToDo(CreateToDoDTO todo)
        {
            var todoEntity = _mapper.Map<ToDo>(todo);
            _unitOfWork.ToDos.Create(todoEntity);
            _unitOfWork.Save();
            return _mapper.Map<ToDoDTO>(todoEntity);
        }

        public void DeleteToDo(int? userId, int todoId)
        {
            var todo = _unitOfWork.ToDos.FindById(todoId);
            if (userId != null && userId == todo.UserId)
            {
                _unitOfWork.ToDos.Delete(todo);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ToDos.Delete(todo);
                _unitOfWork.Save();
            }
        }

        public async Task<List<ToDoDTO>> GetToDosAsync(int? userId)
        {
            if (userId != null)
            {
                return await _mapper.ProjectTo<ToDoDTO>(_unitOfWork.ToDos.FindByCondition(t => t.UserId == userId)).ToListAsync();
            }
            else
            {
                return await _mapper.ProjectTo<ToDoDTO>(_unitOfWork.ToDos.FindAll()).ToListAsync();
            }
        }

        public ToDoDTO UpdateToDo(ToDoDTO todo)
        {
            var entity = _mapper.Map<ToDo>(todo);
            _unitOfWork.ToDos.Update(entity);
            _unitOfWork.Save();
            return _mapper.Map<ToDoDTO>(entity);
        }
    }
}
