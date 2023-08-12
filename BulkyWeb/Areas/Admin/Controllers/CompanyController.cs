﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {   
            if(id == null || id == 0)
            {
                //Create functionality
                return View(new Company());
            }

            else
            {
                //Update functionality
                Company companyObj = _unitOfWork.Company.Get(x => x.Id == id);
                return View(companyObj);
            }
                                    
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {            
            if (ModelState.IsValid)
            {                              
                if(CompanyObj.Id==0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                    TempData["success"] = "Company created successfully";
                }

                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                    TempData["success"] = "Company updated successfully";
                }
                                
                _unitOfWork.Save();
                //TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Company");
            }

            else
            {
                
              return View(CompanyObj);
            }
            
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()         
        {
            List<Company> objProductList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objProductList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {            
            var companyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
                       
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion

    }
}
