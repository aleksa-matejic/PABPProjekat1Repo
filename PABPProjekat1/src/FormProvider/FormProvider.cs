﻿using PABPProjekat1.src.UpdateSupplier;
using PABPProjekat1.src.Categories;
using PABPProjekat1.src.Login;
using PABPProjekat1.src.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PABPProjekat1.src.Orders;

namespace PABPProjekat1.src.FormProvider
{
    // Aleksa: implementation of Singleton pattern over the forms I am using in this application
    public class FormProvider
    {
        #region LoginForm

        public static LoginForm LoginForm
        {
            get
            {
                if (loginForm == null)
                {
                    loginForm = new LoginForm();
                }
                return loginForm;
            }

        }

        private static LoginForm loginForm;

        #endregion

        #region CategoriesForm

        public static CategoriesForm CategoriesForm
        {
            get
            {
                if (categoriesForm == null)
                {
                    categoriesForm = new CategoriesForm();
                }
                return categoriesForm;
            }

            set
            {
                categoriesForm = value;
            }
        }

        public static CategoriesForm GetCategoriesForm()
        {
            return categoriesForm;
        }

        private static CategoriesForm categoriesForm;

        #endregion

        #region UpdateSupplierForm

        public static UpdateSupplierForm UpdateSupplierForm
        {
            get
            {
                if (updateSupplierForm == null)
                {
                    updateSupplierForm = new UpdateSupplierForm();
                }
                return updateSupplierForm;
            }

            set
            {
                updateSupplierForm = value;
            }
        }

        public static UpdateSupplierForm GetUpdateSupplierForm()
        {
            return updateSupplierForm;
        }

        private static UpdateSupplierForm updateSupplierForm;

        #endregion

        #region ProductForm

        public static ProductForm ProductForm
        {
            get
            {
                if (productForm == null)
                {
                    productForm = new ProductForm();
                }
                return productForm;
            }

            set
            {
                productForm = value;
            }
        }

        public static ProductForm GetProductForm()
        {
            return productForm;
        }

        private static ProductForm productForm;

        #endregion

        #region OrdersForm

        public static OrdersForm OrdersForm
        {
            get
            {
                if (ordersForm == null)
                {
                    ordersForm = new OrdersForm();
                }
                return ordersForm;
            }

            set
            {
                ordersForm = value;
            }
        }

        public static OrdersForm GetOrdersForm()
        {
            return ordersForm;
        }

        private static OrdersForm ordersForm;

        #endregion

    }
}
