using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OAUTHandJWT.Models;

public partial class HotelBaseContext : DbContext
{
    public HotelBaseContext()
    {
    }

    public HotelBaseContext(DbContextOptions<HotelBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<ClassNumber> ClassNumbers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Number> Numbers { get; set; }

    public virtual DbSet<NumberClient> NumberClients { get; set; }



    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<TypeNumber> TypeNumbers { get; set; }

    public virtual DbSet<TypeService> TypeServices { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress);

            entity.ToTable("Address");

            entity.Property(e => e.IdAddress).HasColumnName("ID_Address");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.NumberAddress)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Number_Address");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.StatusAddress)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_Address");

          
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(e => e.IdCategoryProduct);

            entity.ToTable("Category_Product");

            entity.HasIndex(e => e.Category, "UQ_Category").IsUnique();

            entity.Property(e => e.IdCategoryProduct).HasColumnName("ID_Category_Product");
            entity.Property(e => e.Category)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.IdCheck);

            entity.ToTable("Check");

            entity.Property(e => e.IdCheck).HasColumnName("ID_Check");
            entity.Property(e => e.DateTimeCheck)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DateTime_Check");
            entity.Property(e => e.NumberCheck)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Number_Check");
            entity.Property(e => e.ScoreId).HasColumnName("Score_ID");

        
        });

        modelBuilder.Entity<ClassNumber>(entity =>
        {
            entity.HasKey(e => e.IdClassNumber);

            entity.ToTable("Class_Number");

            entity.HasIndex(e => e.ClassNumber1, "UQ_ClassNumber").IsUnique();

            entity.Property(e => e.IdClassNumber).HasColumnName("ID_Class_Number");
            entity.Property(e => e.ClassNumber1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ClassNumber");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("Client");

            entity.HasIndex(e => e.LoginClient, "UQ_Login_Client").IsUnique();

            entity.Property(e => e.IdClient).HasColumnName("ID_Client");
            entity.Property(e => e.LoginClient)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Login_Client");
            entity.Property(e => e.MiddlenameClient)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Middlename_Client");
            entity.Property(e => e.NameClient)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Name_Client");
            entity.Property(e => e.NumPassClient)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("NumPass_Client");
            entity.Property(e => e.PasswordClient)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Password_Client");
            entity.Property(e => e.Salt)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SerialPassClient)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SerialPass_Client");
            entity.Property(e => e.SurnameClient)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Surname_Client");
        });

        modelBuilder.Entity<Number>(entity =>
        {
            entity.HasKey(e => e.IdNumber);

            entity.ToTable("Number");

            entity.Property(e => e.IdNumber).HasColumnName("ID_Number");
            entity.Property(e => e.ClassNumberId).HasColumnName("Class_Number_ID");
            entity.Property(e => e.Number1).HasColumnName("Number");
            entity.Property(e => e.PriceNumber)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Price_Number");
            entity.Property(e => e.StatusNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_Number");
            entity.Property(e => e.TypeNumberId).HasColumnName("Type_Number_ID");

         
        });

        modelBuilder.Entity<NumberClient>(entity =>
        {
            entity.HasKey(e => e.IdNumberClient);

            entity.ToTable("Number_Client");

            entity.Property(e => e.IdNumberClient).HasColumnName("ID_Number_Client");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.NumberId).HasColumnName("Number_ID");

         
        });

     

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.NumberId).HasColumnName("Number_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.StatusOrder)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_Order");

        
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition);

            entity.ToTable("Position");

            entity.Property(e => e.IdPosition).HasColumnName("ID_Position");
            entity.Property(e => e.NamePosition)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Name_Position");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");

        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.CategoryProductId).HasColumnName("Category_Product_ID");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Name_Product");
            entity.Property(e => e.PriceProduct)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Price_Product");

        
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.IdScore);

            entity.ToTable("Score");

            entity.Property(e => e.IdScore).HasColumnName("ID_Score");
            entity.Property(e => e.MoneyScore)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Money_Score");
            entity.Property(e => e.NumberClientId).HasColumnName("Number_Client_ID");
            entity.Property(e => e.ServiceId).HasColumnName("Service_ID");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.StatusScore)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_Score");

          
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService);

            entity.ToTable("Service");

            entity.Property(e => e.IdService).HasColumnName("ID_Service");
            entity.Property(e => e.DescriptionService)
                .IsUnicode(false)
                .HasColumnName("Description_Service");
            entity.Property(e => e.NameService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Service");
            entity.Property(e => e.PriceService)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("Price_Service");
            entity.Property(e => e.TypeServiceId).HasColumnName("Type_Service_ID");

          
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.IdStaff);

            entity.HasIndex(e => e.LoginStaff, "UQ_Login_Staff").IsUnique();

            entity.Property(e => e.IdStaff).HasColumnName("ID_Staff");
            entity.Property(e => e.LoginStaff)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Login_Staff");
            entity.Property(e => e.MiddlenameStaff)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Middlename_Staff");
            entity.Property(e => e.NameStaff)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Name_Staff");
            entity.Property(e => e.NumPassStaff)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("NumPass_Staff");
            entity.Property(e => e.PasswordStaff)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Password_Staff");
            entity.Property(e => e.Salt)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SerialPassStaff)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SerialPass_Staff");
            entity.Property(e => e.SurnameStaff)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Surname_Staff");
        });

        modelBuilder.Entity<TypeNumber>(entity =>
        {
            entity.HasKey(e => e.IdTypeNumber);

            entity.ToTable("Type_Number");

            entity.HasIndex(e => e.TypeNumber1, "UQ_TypeNumber").IsUnique();

            entity.Property(e => e.IdTypeNumber).HasColumnName("ID_Type_Number");
            entity.Property(e => e.TypeNumber1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TypeNumber");
        });

        modelBuilder.Entity<TypeService>(entity =>
        {
            entity.HasKey(e => e.IdTypeService);

            entity.ToTable("Type_Service");

            entity.HasIndex(e => e.TypeService1, "UQ_TypeService").IsUnique();

            entity.Property(e => e.IdTypeService).HasColumnName("ID_Type_Service");
            entity.Property(e => e.TypeService1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TypeService");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
