﻿using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domains.Core;
using Util.Domains;

namespace Applications.Domains.Commons.Models {
    /// <summary>
    /// 图标分类
    /// </summary>
    public class IconCategory : TenantAggregateRoot {
        /// <summary>
        /// 初始化图标分类
        /// </summary>
        public IconCategory()
            : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化图标分类
        /// </summary>
        /// <param name="id">图标分类标识</param>
        public IconCategory( Guid id )
            : base( id ) {
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required( ErrorMessage = "分类名称不能为空" )]
        [StringLength( 50, ErrorMessage = "分类名称输入过长，不能超过50位" )]
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required( ErrorMessage = "创建时间不能为空" )]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( DomainResource ), ErrorMessageResourceName = "SortIdIsNull" )]
        public int? SortId { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "图标分类编号", Id );
            AddDescription( "租户编号", TenantId );
            AddDescription( "分类名称", Name );
            AddDescription( "创建时间", CreateTime );
            AddDescription( "排序号", SortId );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            CreateTime = DateTime.Now;
        }
    }
}