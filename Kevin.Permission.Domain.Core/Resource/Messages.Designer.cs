﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kevin.Permission.Domain.Core.Resource {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kevin.Permission.Domain.Core.Resource.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 访问对象的操作中不包括给定的操作 的本地化字符串。
        /// </summary>
        internal static string exception_AccessObjectNotContainsOperation {
            get {
                return ResourceManager.GetString("exception_AccessObjectNotContainsOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 无效的访问对象,访问对象必须为非范围控制的访问对象 的本地化字符串。
        /// </summary>
        internal static string exception_AccessObjectRangeAccessNeedFalse {
            get {
                return ResourceManager.GetString("exception_AccessObjectRangeAccessNeedFalse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进行权限计算的权限配置对象的访问对象错误 的本地化字符串。
        /// </summary>
        internal static string exception_CommonPermissionPermissionCalculateInvalidAccessObject {
            get {
                return ResourceManager.GetString("exception_CommonPermissionPermissionCalculateInvalidAccessObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进行权限计算的权限配置对象的访问对象的操作配置对象错误 的本地化字符串。
        /// </summary>
        internal static string exception_CommonPermissionPermissionCalculateInvalidOperationPermissionConfig {
            get {
                return ResourceManager.GetString("exception_CommonPermissionPermissionCalculateInvalidOperationPermissionConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 无效的角色继承类型值 的本地化字符串。
        /// </summary>
        internal static string exception_InvalidInheritValue {
            get {
                return ResourceManager.GetString("exception_InvalidInheritValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进行操作权限计算的操作权限配置对象错误 的本地化字符串。
        /// </summary>
        internal static string exception_OperationPermissionCalculateInvalidOperationConfig {
            get {
                return ResourceManager.GetString("exception_OperationPermissionCalculateInvalidOperationConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进行权限设置的操作不属于权限配置对象中访问对象的操作 的本地化字符串。
        /// </summary>
        internal static string exception_PermissionConfigBase_SetOperationPermission_OperationInvalid {
            get {
                return ResourceManager.GetString("exception_PermissionConfigBase_SetOperationPermission_OperationInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进行筛选的角色标识符列表无效 的本地化字符串。
        /// </summary>
        internal static string exception_PermissionConfigBaseRolesSpecification_InvalidRoleIds {
            get {
                return ResourceManager.GetString("exception_PermissionConfigBaseRolesSpecification_InvalidRoleIds", resourceCulture);
            }
        }
    }
}
