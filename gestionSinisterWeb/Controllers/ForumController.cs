using CodeKicker.BBCode;
using Insurance.Domaine.Entity;
using Insurance.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ForumController : Controller
    {
        TopicService Ts = new TopicService();
        SousCategoryService Ss = new SousCategoryService();
        UserService Us = new UserService();
        CategoryService Cs = new CategoryService();
        FavorisService Fs = new FavorisService();
        MessagesService Ms = new MessagesService();
        ReponseService Rs = new ReponseService();
        LikesService Ls = new LikesService();

        public static user currentuser= new user();
        public static List<user> users = null;
        public static string msg = "";
        




        // GET: Forum
        public ActionResult First()
        {
            var client = new RestClient("http://localhost:18080/insurance-web/pidev/");
            var request = new RestRequest("Category", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<category>> Cat = client.Execute<List<category>>(request);


            ViewBag.topic = Ts.GetAll();
            ViewBag.soucategory = Ss.GetAll();
            ViewBag.message = Ms.GetAll();
            ViewBag.user = Us.GetAll();


            return View(Cs.GetAll());
        }

        public ActionResult AddFavoris(int id , int iduser, int idcat)
        {

            if (iduser==0)
            {
                msg= "Sorry, you have to connect";
                return RedirectToAction("Login");
            }
            else { 
            var listf = Fs.GetAll();
            favoris f = new favoris();
            f.idTopic = id;
            f.idUser = iduser;

            f.date = DateTime.Now;

            Fs.Add(f);
            Fs.Commit();
            return RedirectToAction("ViewForum", new
            {
          id=idcat
            });

            }
        }


        public ActionResult AddFavoris2(int id, int iduser)
        {

            if (iduser == 0)
            {
                msg = "Sorry, you have to connect";
                return RedirectToAction("Login");
            }
            else
            {
                var listf = Fs.GetAll();
                favoris f = new favoris();
                f.idTopic = id;
                f.idUser = iduser;

                f.date = DateTime.Now;

                Fs.Add(f);
                Fs.Commit();
                return RedirectToAction("ViewTopic", new
                {
                    id = id,
                    idRep = 0,
                });

            }
        }



        public ActionResult AddLike(int id, int iduser)
        {

            if (iduser == 0)
            {
                msg = "Sorry, you have to connect";
                return RedirectToAction("Login");
            }
            else
            {
                var listf = Ls.GetAll();
                likes l = new likes();
                l.idmessage = id;
                l.iduser = iduser;

                l.date = DateTime.Now;
                messages messages = Ms.GetById(id);
                messages.nbLike = messages.nbLike + 1;
                Ms.Update(messages);
                Ms.Commit();


                Ls.Add(l);
                Ls.Commit();
                return RedirectToAction("ViewTopic", new
                {
                    id = id,
                    idRep = id,
                });

            }
        }




        [HttpPost]
        public ActionResult ViewTopic(int id)
        {


            try
            {
             

                var contenu = Request.Form["message"];

               

                var message = new topic();

                message.contenu = (contenu);

                var restClient = new RestClient("http://localhost:18080/insurance-web/pidev/");
                restClient.AddDefaultHeader("accept", "*/*");
                var request = new RestRequest("Message?idtopic="+id, Method.POST);
                request.AddJsonBody(new
                {
                    
                    contenu = contenu

                });
                var response = restClient.Execute(request);

            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                return RedirectToAction("AddTopic");
            }

            List<messages> messages = (List<messages>)Ms.GetAll();
            int count = messages.Count()-1;

            int idRep = messages[count].idMessage ;

            return RedirectToAction("ViewTopic", new
            {
                id = id,
                idRep = idRep,
            });
        }



        public ActionResult DeleteFavoris(int id, int iduser)
        {

            if (iduser == 0)
            {
                msg = "Sorry, you have to connect";
                return RedirectToAction("Login");
            }
            else
            {
                var listf = Fs.GetAll();
                   favoris f = new favoris();
                foreach (var item in listf)
                {
                    if  (item.idTopic==id && item.idUser==iduser)
                    {
                        f = item;
                    }
                }


                Fs.Delete(f);
                Fs.Commit();
              
                return RedirectToAction("ViewTopic", new
                {
                    id = id,
                idRep=0,
                });

            }
        }


        public ActionResult ViewForum(int id)
        {
            ViewBag.message = Ms.GetAll();
            ViewBag.idcategory = id;
            ViewBag.topic = Ts.GetAll();
            ViewBag.soucategory = Ss.GetAll();
            ViewBag.user = Us.GetAll();
            ViewBag.lastpost= Ms.LastPost();
            ViewBag.fav = Fs.GetAll();

            return View(Ss.GetAll());
        }

        public ActionResult AddTopic()
        {

            ViewBag.topic = Ts.GetAll();
            ViewBag.soucategory = Ss.GetAll();
            ViewBag.user = Us.GetAll();

            return View(Ss.GetAll());


            return View();
        }
        [HttpPost]
        public ActionResult AddTopic(HttpPostedFileBase photo)
        {
            try
            {
                var sujet = Request.Form["subject"];

                var contenu = Request.Form["message"];
                    
                var soucat = Request.Form["subject1"];
                var x=Ss.getByName(soucat);

                var top = new topic();

                top.contenu = (sujet); 
                top.sujet = (contenu);

                var restClient = new RestClient("http://localhost:18080/insurance-web/pidev/");
                restClient.AddDefaultHeader("accept", "*/*");
                var request = new RestRequest("Topic?id="+x[0].idSousCategory, Method.POST);
                request.AddJsonBody(new
                {
                    

                });
                var response = restClient.Execute(request);
                return RedirectToAction("First");

            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                return RedirectToAction("AddTopic");
            }
        }



        public ActionResult ViewTopic(int id, int idRep)
        {
            ViewBag.message = Ms.GetAll();
            ViewBag.idtopic= id;
            ViewBag.topic = Ts.GetAll();
            ViewBag.soucategory = Ss.GetAll();
            ViewBag.user = Us.GetAll();
            ViewBag.fav = Fs.GetAll();
            ViewBag.idRep = idRep;



            return View();
        }

        public static string bbcode(String text)
        {




            var client = new RestClient("http://localhost:18080/insurance-web/pidev/");
            var request = new RestRequest("insurance?text="+text, Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<string>> Cat = client.Execute<List<string>>(request);
            string ccc = "dddd";
            string xx = Cat.Content;
           
            return Cat.Content;
        }



        public ActionResult Login()
        {



            ViewBag.ErrorMessage = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Login(HttpPostedFileBase phot)
        {
            var email = Request.Form["login"];
            var password = Request.Form["password"];
            var client = new RestClient("http://localhost:18080/insurance-web/pidev/");
            var request = new RestRequest("user/"+email+"/"+password, Method.GET);
            request.AddHeader("Content-type", "application/json");


            IRestResponse<List<user>> user = client.Execute<List<user>>(request);
           
            foreach (var item in user.Data)
            {
                users = user.Data;
                item.Online = 1;
            }
            currentuser = user.Data[0];
           // currentuser.Online = 1;

            return RedirectToAction("First");
        }

        public ActionResult Logout()
        {
            currentuser.id = 0;
            return RedirectToAction("First");



        }




    }
}