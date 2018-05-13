﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLHS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            this.PhanCongs = new HashSet<PhanCong>();
            this.TaiKhoans = new HashSet<TaiKhoan>();
        }
        [DisplayName("IDGV")]
        public int IDGV { get; set; }
        [DisplayName("Mã giáo viên")]
        public string MaGV { get; set; }
        [DisplayName("Họ")]
        public string Ho { get; set; }
        [DisplayName("Tên")]
        public string Ten { get; set; }
        [DisplayName("Giới tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("SĐT")]
        public string Sdt { get; set; }
        [DisplayName("Môn học")]
        public Nullable<int> MaMH { get; set; }
    
        public virtual MonHoc MonHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
