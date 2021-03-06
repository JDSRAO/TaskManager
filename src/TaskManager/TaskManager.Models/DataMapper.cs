﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Entity;
using TaskManager.Models.DTO;

namespace TaskManager.Models
{
    public class DataMapper
    {
        private static bool _isInitialized;

        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<UserTask, UserTaskDto>();
                    cfg.CreateMap<UserTaskDto, UserTask>();
                });
                _isInitialized = true;
            }
        }

        public static T Convert<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
