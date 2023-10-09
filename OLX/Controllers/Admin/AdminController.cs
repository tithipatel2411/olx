using OLX.Models.Admin;
using OLX_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLX.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        Admin_DataAccess productCatRepository = null;
        public AdminController()
        {
            productCatRepository = new Admin_DataAccess();
        }

        public ActionResult Dashboard()
        {
            return View("Dashboard", "Admin_Layout");
        }

        public ActionResult SubCategoryList()
        {
            IEnumerable<ProductSubCategoryModeljoin> productDetails = productCatRepository.GetProductDetailsLists();

            return View("SubCategoryList", "Admin_Layout", productDetails);
        }

        public ActionResult SubCategoryListDetails(int productSubCategoryId)
        {
            ProductSubCategoryModeljoin productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View("SubCategoryListDetails", "Admin_Layout", productDetails);
        }

        public ActionResult SubCategoryListCreate()
        {
            return View("SubCategoryListCreate", "Admin_Layout");
        }

        [HttpPost]
        public ActionResult SubCategoryListCreate(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                TempData["AlertMessage"] = "Product Subcategory Added successfully......";
                productCatRepository.AddProductDetails(productDetails);

                return RedirectToAction(nameof(SubCategoryList));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult SubCategoryListEdit(int productSubCategoryId)
        {
            ProductSubCategoryModeljoin productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View("SubCategoryListEdit", "Admin_Layout", productDetails);
        }

        [HttpPost]
        public ActionResult SubCategoryListEdit(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                TempData["AlertMessage"] = "Product Subcategory Edited successfully......";
                productCatRepository.UpdateProductDetails(productDetails);
                return RedirectToAction(nameof(SubCategoryList));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SubCategoryListDelete(int productSubCategoryId)
        {
            ProductSubCategoryModeljoin productDetails = productCatRepository.GetProductDetails(productSubCategoryId);
            return View("SubCategoryListDelete", "Admin_Layout", productDetails);
        }

        [HttpPost]
        public ActionResult SubCategoryListDelete(ProductSubCategoryModeljoin productDetails)
        {
            try
            {
                TempData["AlertMessage"] = "Product Subcategory Deleted successfully......";
                productCatRepository.DeleteProductDetails(productDetails.@productSubCategoryId);
                return RedirectToAction(nameof(SubCategoryList));
            }
            catch
            {
                return View();
            }
        }
    }
}