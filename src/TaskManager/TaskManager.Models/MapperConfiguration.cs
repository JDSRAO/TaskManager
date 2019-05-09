using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = TaskManager.Models.Entity;
using Dto = TaskManager.Models.DTO;

namespace TaskManager.Models
{
    public class MapperConfiguration
    {
        private static bool _isInitialized;

        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Entity.UserTask, Dto.UserTaskDto>();
                });
                _isInitialized = true;
            }
        }
    }
}
