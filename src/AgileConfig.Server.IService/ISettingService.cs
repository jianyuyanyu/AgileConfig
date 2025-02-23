﻿using AgileConfig.Server.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgileConfig.Server.IService
{
    public interface ISettingService : IDisposable
    {
        static string[] EnvironmentList { get; set; }

        static string IfEnvEmptySetDefault(ref string env)
        {
            if (!string.IsNullOrEmpty(env))
            {
                return env;
            }

            if (EnvironmentList == null || EnvironmentList.Length == 0)
            {
                throw new ArgumentNullException(nameof(EnvironmentList));
            }

            env = EnvironmentList[0];

            return env;
        }

        Task<Setting> GetAsync(string id);
        Task<bool> AddAsync(Setting setting);

        Task<bool> DeleteAsync(Setting setting);

        Task<bool> DeleteAsync(string settingId);

        Task<bool> UpdateAsync(Setting setting);

        /// <summary>
        /// 获取所有的设定
        /// </summary>
        /// <returns></returns>
        Task<List<Setting>> GetAllSettingsAsync();

        /// <summary>
        /// 获取环境列表
        /// </summary>
        /// <returns></returns>
        Task<string[]> GetEnvironmentList();
    }
}
