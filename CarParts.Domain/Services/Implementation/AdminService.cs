using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI.Services;
using CarParts.DataAccess;
using CarParts.Domain.Services.Abstraction;
using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoResult;
using CarParts.Dto.DtoModels;
using System.Web.Http.ModelBinding;
using CarParts.Helpers;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Bogus;

namespace CarParts.Domain.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _mapper;

        public AdminService(EFDbContext context,
            UserManager<DbUser> userManager,
            SignInManager<DbUser> signInManager,
            IConfiguration configuration,
            IHostingEnvironment env,
            IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _configuration = configuration;
            _env = env;
            _mapper = mapper;
        }

        public async Task<ResultDto> addUser(CreateUserDto user)
        {
            var newUser = new DbUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
                Name = user.Name,
                Surname = user.Surname

            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = null,
                };
            }
            //IEmailSender emailServer = new EmailSender(this._configuration);
            //await emailServer.SendEmailAsync(model.Email, "Confirm Email",
            //   $"Please confirm your email by clicking here: " +
            //   $"<a href='{callbackUrl}'>link</a>");
            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = null,
            };
        }


        public async Task<ResultDto> deleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccessful = true,
                    collectionResult = null,
                };
            }
            return new ResultDto
            {
                IsSuccessful = false,
                collectionResult = null,
            };
        }

        public async Task<CollectionResultDto<UserDto>> listUsers(int page)
        {
            int userCOunt = 15;
            //var user = await _userManager.GetUsersForClaimAsync();
            var user = _context.Users.Skip(userCOunt * (page - 1)).Take(userCOunt).ToList();
            var result = _mapper.Map<List<UserDto>>(user);
            return new CollectionResultDto<UserDto>
            {
                IsSuccessful = true,
                Data = result,
            };
        }
        public async Task<ResultDto> addCategory(CreateCategoryDto category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Image = category.Image,
                Description = category.Description,
                ParentId = category.Parent_id,
                IsArchive = true,

            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = null,
            };
        }
        public async Task<ResultDto> removeCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null && category.Categories.Count()==0)
            {

                _context.Remove(category);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccessful = true,
                    collectionResult = null,
                };
            }
            return new ResultDto
            {
                IsSuccessful = false,
                collectionResult = null,
            };
        }
        public async Task<ResultDto> addFilterGroup(string filterName, string[] filterValue)
        {

            var filter = _context.FilterNames.FirstOrDefault(el => el.Name.ToUpper() == filterName.ToUpper());
            List<FilterValue> filterValues = new List<FilterValue>();

            for (int i = 0; i < filterValue.Count(); i++)
            {
                filterValues.Add(new FilterValue { Name = filterValue[i] });
            }


            if (filter != null)
            {
                _context.FilterValues.AddRange(filterValues);
            }
            else
            {
                filter = new FilterName { Name = filterName };
                _context.FilterNames.Add(filter);
                _context.FilterValues.AddRange(filterValues);
            }
            _context.SaveChanges();

            for (int i = 0; i < filterValues.Count(); i++)
            {
                _context.FilterNameGroups.Add(new FilterNameGroup { FilterNameId=filter.Id , FilterValueId = filterValues[i].Id });
            }

            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = null,
            };
        }
        public string productSeeder()
        {

            return "ok";
        }

    }
}
