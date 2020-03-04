﻿using Senparc.Scf.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Senparc.Scf.XscfBase
{
    /// <summary>
    /// 所有 XSCF 模块注册的基类
    /// </summary>
    public abstract class XscfRegisterBase : IXscfRegister
    {
        /// <summary>
        /// 模块名称，要求全局唯一
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// 编号，要求全局唯一
        /// </summary>
        public abstract string Uid { get; }
        /// <summary>
        /// 版本号
        /// </summary>
        public abstract string Version { get; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public abstract string MenuName { get; }
        /// <summary>
        /// Icon图标
        /// </summary>
        public abstract string Icon { get; }
        /// <summary>
        /// 说明
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// 注册方法，注册的顺序决定了界面中排列的顺序
        /// </summary>
        public abstract IList<Type> Functions { get; }
        /// <summary>
        /// 如果提供了 UI 界面，必须指定一个首页
        /// </summary>
        public virtual string HomeUrl => null;
        /// <summary>
        /// 安装代码
        /// </summary>
        public virtual Task InstallOrUpdateAsync(InstallOrUpdate installOrUpdate)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// 卸载代码
        /// </summary>
        public virtual async Task UninstallAsync(Func<Task> unsinstallFunc)
        {
            await unsinstallFunc().ConfigureAwait(false);
        }
    }
}