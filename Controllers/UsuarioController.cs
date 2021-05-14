﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
//importando los modelos de base de datos
using ASP2184587.Models;


namespace ASP2184587.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.usuarios.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities())
                {
                    usuario.password = UsuarioController.hashSHA1(usuario.password);
                    db.usuarios.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
                
            }
        }

        public static string hashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                var findUser = db.usuarios.Find(id);
                return View(findUser);

            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    usuario findUser = db.usuarios.Where(a => a.id == id).FirstOrDefault();
                    return View();
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usuario editUser)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    usuario user = db.usuarios.Find(editUser.id);
                    user.nombre = editUser.nombre;
                    user.apellido = editUser.apellido;
                    user.email = editUser.email;
                    user.password = UsuarioController.hashSHA1(editUser.password);

                    db.SaveChanges();

                    return RedirectToAction("index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var findUser = db.usuarios.Find(id);
                    db.usuarios.Remove(findUser);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

    }
}