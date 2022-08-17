using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace canteen_management_system.Models
{
    public partial class canteen_manege_systemContext : DbContext
    {
        public canteen_manege_systemContext()
        {
        }

        public canteen_manege_systemContext(DbContextOptions<canteen_manege_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChefCollectOrderMaster> ChefCollectOrderMaster { get; set; }
        public virtual DbSet<FeedbackMaster> FeedbackMaster { get; set; }
        public virtual DbSet<FoodCategoryMaster> FoodCategoryMaster { get; set; }
        public virtual DbSet<FoodItemMaster> FoodItemMaster { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<PaymentMaster> PaymentMaster { get; set; }
        public virtual DbSet<RatingMaster> RatingMaster { get; set; }
        public virtual DbSet<SpecialityMaster> SpecialityMaster { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AEQVFRS;Initial Catalog=canteen_manege_system;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChefCollectOrderMaster>(entity =>
            {
                entity.HasKey(e => e.ChefCollectOrderId);

                entity.ToTable("chef_collect_order_master");

                entity.Property(e => e.ChefCollectOrderId).HasColumnName("chef_collect_order_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.IsDone).HasColumnName("is_done");

                entity.Property(e => e.IsStart).HasColumnName("is_start");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChefCollectOrderMaster)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_chef_collect_order_master_user_master");
            });

            modelBuilder.Entity<FeedbackMaster>(entity =>
            {
                entity.HasKey(e => e.FeedbackId);

                entity.ToTable("feedback_master");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasColumnName("feedback")
                    .HasColumnType("text");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FeedbackMaster)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_feedback_master_user_master");
            });

            modelBuilder.Entity<FoodCategoryMaster>(entity =>
            {
                entity.HasKey(e => e.FoodCatId);

                entity.ToTable("food_category_master");

                entity.Property(e => e.FoodCatId).HasColumnName("food_cat_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FoodCatName)
                    .IsRequired()
                    .HasColumnName("food_cat_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<FoodItemMaster>(entity =>
            {
                entity.HasKey(e => e.FoodItemId);

                entity.ToTable("food_item_master");

                entity.Property(e => e.FoodItemId).HasColumnName("food_item_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FoodCatId).HasColumnName("food_cat__id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasColumnType("text");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("item_description")
                    .HasColumnType("text");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FoodCat)
                    .WithMany(p => p.FoodItemMaster)
                    .HasForeignKey(d => d.FoodCatId)
                    .HasConstraintName("FK_food_item_master_food_category_master");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_item");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FoodItemId).HasColumnName("food_item_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.OrderMasterId).HasColumnName("order_master_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK_order_item_food_item_master");

                entity.HasOne(d => d.OrderMaster)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderMasterId)
                    .HasConstraintName("FK_order_item_order_master");
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.ToTable("order_master");

                entity.Property(e => e.OrderMasterId)
                    .HasColumnName("order_master_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.Property(e => e.OrderDeliverytime).HasColumnName("order_deliverytime");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OrderMasterNavigation)
                    .WithOne(p => p.InverseOrderMasterNavigation)
                    .HasForeignKey<OrderMaster>(d => d.OrderMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_master_order_master");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderMaster)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_master_user_master");
            });

            modelBuilder.Entity<PaymentMaster>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("payment_master");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasColumnName("payment_mode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.PaymentMaster)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_master_order_item");
            });

            modelBuilder.Entity<RatingMaster>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.ToTable("rating_master");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FoodItemId).HasColumnName("food_item_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.RatingMaster)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK_rating_master_food_item_master");
            });

            modelBuilder.Entity<SpecialityMaster>(entity =>
            {
                entity.HasKey(e => e.SpecialityId);

                entity.ToTable("speciality_master");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.FoodCatId).HasColumnName("food_cat_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsApproed).HasColumnName("is_approed");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasColumnName("qualification")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.FoodCat)
                    .WithMany(p => p.SpecialityMaster)
                    .HasForeignKey(d => d.FoodCatId)
                    .HasConstraintName("FK_speciality_master_food_category_master");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SpecialityMaster)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_speciality_master_user_master");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_master");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("text");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasColumnName("district")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("e_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnName("update_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType).HasColumnName("user_type");
            });
        }
    }
}
