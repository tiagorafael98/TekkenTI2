namespace TekkenTI2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TekkenTI2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TekkenTI2.Models.TekkenDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TekkenTI2.Models.TekkenDB context)
        {
            var user = new List<Utilizadores> {
                new Utilizadores {ID=1, UserName ="tiago-rafael_98@hotmail.com", NomeCompleto = "Rafael Andr� Campos Gon�alves", DataNascimento = new DateTime(1996,5,3),  Email = "tiago-rafael_98@hotmail.com"},
                new Utilizadores {ID=2, UserName ="racggoncalves@gmail.com", NomeCompleto = "Tiago Jorge Campos Gon�alves", Email = "tjorge@gmail.com", DataNascimento = new DateTime(1992,4,11)},
                new Utilizadores {ID=3, UserName ="racggoncalves@gmail.com", NomeCompleto = "Sim�o Pedro Oliveira Moleiro", Email = "symao96@gmail.com", DataNascimento = new DateTime(1996,10,2)},
                new Utilizadores {ID=4, UserName ="racggoncalves@gmail.com", DataNascimento = new DateTime(1995,7,2), NomeCompleto = "Beatriz Bangur� Okica de S�", Email = "beatrizbokica@gmail.com", DataNascimento = new DateTime(1995,7,2)},
                new Utilizadores {ID=5, UserName ="racggoncalves@gmail.com" , NomeCompleto = "Patricia Sofia Margalh�es Faustino", Email = "patricia.sofia.faustino@gmail.com", DataNascimento = new DateTime(1995,10,2)},
                new Utilizadores {ID=6, UserName ="racggoncalves@gmail.com", NomeCompleto = "Marta Andreia Campos Ribeiro", Email = "Mandreia@gmail.com", DataNascimento = new DateTime(1997,8,22)},
            };

            user.ForEach(dd => context.Utilizadores.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();

            var storeR = new RoleStore<IdentityRole>(context);
            var managerR = new RoleManager<IdentityRole>(storeR);

            if (!managerR.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };

                managerR.Create(role);
            }
            if (!managerR.Roles.Any(r => r.Name == "Viewer"))
            {
                var role = new IdentityRole { Name = "Viewer" };

                managerR.Create(role);
            }

            /////////////////////////// USERS ///////////////////////////////////
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            /////////////////////////// ADMIN ///////////////////////////////////
            var us = user[0]; //Primeiro utilizador do seed da tabela de Users
            if (!context.Utilizadores.Any(u => u.UserName == us.Email))
            {
                var u = new ApplicationUser
                {
                    UserName = us.Email,
                    Email = us.Email
                };

                manager.Create(u, "123qweQWE#"); // Palavra passe do admin 
                manager.AddToRole(u.Id, "Admin");
            }
            //Os restantes users s�o views da aplica��o web 
            for (int i = 1; i < user.Count(); i++)
            {
                var us2 = user[i];
                if (!context.Users.Any(u => u.UserName == us2.Email))
                {
                    var u = new ApplicationUser
                    {
                        UserName = us2.Email,
                        Email = us2.Email
                    };

                    manager.Create(u, "123Querty#");
                    manager.AddToRole(u.Id, "Viewer");
                }
            }

            // adiciona PLATAFORMAS

            var plataformas = new List<Plataformas> {
                new Plataformas {ID=1, Jogo="Tekken", Plataforma="Arcade", Ano="1994"},
                new Plataformas {ID=2, Jogo="Tekken", Plataforma="PlayStation", Ano="1995"},
                new Plataformas {ID=3, Jogo="Tekken 2", Plataforma="Arcade", Ano="1995"},
                new Plataformas {ID=4, Jogo="Tekken 2", Plataforma="PlayStation", Ano="1996"},
                new Plataformas {ID=5, Jogo="Tekken 3", Plataforma="Arcade", Ano="1997"},
                new Plataformas {ID=6, Jogo="Tekken 3", Plataforma="PlayStation", Ano="1998"},
                new Plataformas {ID=7, Jogo="Tekken 4", Plataforma="Arcade", Ano="2001"},
                new Plataformas {ID=8, Jogo="Tekken 4", Plataforma="PlayStation 2", Ano="2002"},
                new Plataformas {ID=9, Jogo="Tekken 5", Plataforma="Arcade", Ano="2004"},
                new Plataformas {ID=10, Jogo="Tekken 5", Plataforma="PlayStation 2", Ano="2005"},
                new Plataformas {ID=11, Jogo="Tekken 5: Dark Resurrection", Plataforma="Arcade", Ano="2005"},
                new Plataformas {ID=12, Jogo="Tekken 5: Dark Resurrection", Plataforma="PlayStation Portable", Ano="2006"},
                new Plataformas {ID=13, Jogo="Tekken 6", Plataforma="Arcade", Ano="2007"},
                new Plataformas {ID=14, Jogo="Tekken 6", Plataforma="PlayStation 3", Ano="2009"},
                new Plataformas {ID=15, Jogo="Tekken 6", Plataforma="Xbox 360", Ano="2009"},
                new Plataformas {ID=16, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="Arcade", Ano="2008"},
                new Plataformas {ID=17, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="PlayStation 3", Ano="2009"},
                new Plataformas {ID=18, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="Xbox 360", Ano="2009"},
                new Plataformas {ID=19, Jogo="Tekken 6: Bloodline Rebellion", Plataforma="PlayStation Portable", Ano="2009"},
                new Plataformas {ID=20, Jogo="Tekken 7", Plataforma="Arcade", Ano="2015"},
                new Plataformas {ID=21, Jogo="Tekken 7", Plataforma="PlayStation 4", Ano="2017"},
                new Plataformas {ID=22, Jogo="Tekken 7", Plataforma="Xbox One", Ano="2017"},
                new Plataformas {ID=23, Jogo="Tekken 7", Plataforma="Microsoft Windows", Ano="2017"},
                new Plataformas {ID=24, Jogo="Tekken Tag Tournament", Plataforma="Arcade", Ano="1999"},
                new Plataformas {ID=25, Jogo="Tekken Tag Tournament", Plataforma="PlayStation 2", Ano="2000"},
                new Plataformas {ID=26, Jogo="Tekken Tag Tournament 2", Plataforma="Arcade", Ano="2011"},
                new Plataformas {ID=27, Jogo="Tekken Tag Tournament 2", Plataforma="PlayStation 3", Ano="2012"},
                new Plataformas {ID=28, Jogo="Tekken Tag Tournament 2", Plataforma="Xbox 360", Ano="2012"},
                new Plataformas {ID=29, Jogo="Tekken Tag Tournament 2", Plataforma="Wii U", Ano="2012"},
            };
            plataformas.ForEach(cc => context.Plataformas.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();

            // adiciona JOGO

            var jogos = new List<Jogo> {
               new Jogo {ID=1, Titulo="Tekken",  Genero="Luta", Fotografia="Tekken.jpg",  ListaDePlataformas = new List<Plataformas>{ plataformas[0], plataformas[1] } },
               new Jogo {ID=2, Titulo="Tekken 2",  Genero="Luta", Fotografia="Tekken2.jpg",  ListaDePlataformas = new List<Plataformas>{ plataformas[2], plataformas[3] } },
               new Jogo {ID=3, Titulo="Tekken 3",  Genero="Luta", Fotografia="Tekken3.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[4], plataformas[5] } },
               new Jogo {ID=4, Titulo="Tekken 4",  Genero="Luta", Fotografia="Tekken4.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[6], plataformas[7] } },
               new Jogo {ID=5, Titulo="Tekken 5",  Genero="Luta", Fotografia="Tekken5.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[8], plataformas[9] } },
               new Jogo {ID=6, Titulo="Tekken 5: Dark Resurrection",  Genero="Luta", Fotografia="Tekken5DarkRessurrection.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[10], plataformas[11] } },
               new Jogo {ID=7, Titulo="Tekken 6",  Genero="Luta", Fotografia="Tekken6.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[12], plataformas[13], plataformas[14] } },
               new Jogo {ID=8, Titulo="Tekken 6: Bloodline Rebellion",  Genero="Luta", Fotografia="Tekken6BloodlineRebellion.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[15], plataformas[16], plataformas[17], plataformas[18] } },
               new Jogo {ID=9, Titulo="Tekken 7",  Genero="Luta", Fotografia="Tekken7.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[19], plataformas[20], plataformas[21], plataformas[22] } },
               new Jogo {ID=10, Titulo="Tekken Tag Tournament",  Genero="Luta", Fotografia="TekkenTagTournament.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[23], plataformas[24] } },
               new Jogo {ID=11, Titulo="Tekken Tournament 2",  Genero="Luta", Fotografia="TekkenTagTournament2.jpg", ListaDePlataformas = new List<Plataformas>{ plataformas[25], plataformas[26], plataformas[27], plataformas[28] } },

};
            jogos.ForEach(vv => context.Jogo.AddOrUpdate(v => v.ID, vv));
            context.SaveChanges();

            // adiciona PERSONAGENS

            var personagens = new List<Personagens> {
                new Personagens {ID=1, Nome="Kazuya Mishima", Origem="Jap�o", Estreia="Tekken 1", TipoLuta="Carat� de Combate estilo Mishima", Fotografia="Kazuya.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=2, Nome="Nina Williams", Origem="Irlanda", Estreia="Tekken 1", TipoLuta="Artes de Assassinato baseadas no Aikido e no Koppojutsu", Fotografia="Nina.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=3, Nome="Marshall Law", Origem="USA", Estreia="Tekken 1", TipoLuta="Artes Marciais", Fotografia="MarshallLaw.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] } },

                new Personagens {ID=4, Nome="Yoshimitsu", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Ninjutsu Manji Avan�ado", Fotografia="Yoshimitsu.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=5, Nome="Jack", Origem="Russia", Estreia="Tekken 1", TipoLuta="For�a Bruta", Fotografia="Jack.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=6, Nome="King", Origem="Mexico", Estreia="Tekken 1", TipoLuta="Pro-Wrestling", Fotografia="King.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1] }},

                new Personagens {ID=7, Nome="Anna Williams", Origem="Irlanda", Estreia="Tekken 1", TipoLuta="T�cnicas baseadas em Aikido, Koppojutsu e artes de Assassinato", Fotografia="Anna.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[2], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=8, Nome="Ganryu", Origem="Jap�o", Estreia="Tekken 1", TipoLuta="Sumo", Fotografia="Ganryu.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=9, Nome="Lee Chaolan", Origem="China", Estreia="Tekken 1", TipoLuta="Carat� de Combate estilo Mishima com Artes Marciais", Fotografia="Lee.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=10, Nome="Prototype Jack", Origem="Russia", Estreia="Tekken 1", TipoLuta="For�a Bruta", Fotografia="PrototypeJack.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=11, Nome="Armor King", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Pro-Wrestling", Fotografia="ArmorKing.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[9] }},

                new Personagens {ID=12, Nome="Kunimitsu", Origem="Jap�o", Estreia="Tekken 1", TipoLuta="Manji Ninjutsu", Fotografia="Kunimitsu.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=13, Nome="Kuma", Origem="Jap�o", Estreia="Tekken 1", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="Kuma.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1] }},

                new Personagens {ID=14, Nome="Heihachi Mishima", Origem="Jap�o", Estreia="Tekken 1", TipoLuta="Carat� de Combate estilo Mishima", Fotografia="Heihachi.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=15, Nome="Paul", Origem="USA", Estreia="Tekken 1", TipoLuta="Judo", Fotografia="Paul.jpg", ListaDeJogos = new List<Jogo>{ jogos [0], jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=16, Nome="Devil Kazuya", Origem="Desconhecida", Estreia="Tekken 1", TipoLuta="Carat� de Combate estilo Mishima", Fotografia="DevilKazuya.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[8],  jogos[9], jogos[10] }},

                new Personagens {ID=17, Nome="Michelle Chang", Origem="USA", Estreia="Tekken 1", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseado em artes marciais chinesas", Fotografia="Michelle.jpg", ListaDeJogos = new List<Jogo>{ jogos[0], jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=18, Nome="Jun Kazama", Origem="Jap�o", Estreia="Tekken 2", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Jun.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=19, Nome="Lei Wulong", Origem="Hong Kong", Estreia="Tekken 2", TipoLuta="Five Animals Form e Drunken Boxing baseado em artes marciais chinesas", Fotografia="Lei.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=20, Nome="Wang Jinrei", Origem="China", Estreia="Tekken 2", TipoLuta="Xin Yi Liu He Quan", Fotografia="Wang.jpg", ListaDeJogos = new List<Jogo>{ jogos [0], jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=21, Nome="Roger", Origem="Amostra de DNA retirada de um canguru", Estreia="Tekken 2", TipoLuta="Commando Wrestling", Fotografia="Roger.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[9] }},

                new Personagens {ID=22, Nome="Alex", Origem="Amostra de DNA retirada de um inseto", Estreia="Tekken 2", TipoLuta="Commando Wrestling", Fotografia="Alex.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[9], jogos[10] }},

                new Personagens {ID=23, Nome="Baek Doo San", Origem="Coreia do Sul", Estreia="Tekken 2", TipoLuta="Taekwondo", Fotografia="Baek.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=24, Nome="Bruce Irvin", Origem="USA", Estreia="Tekken 2", TipoLuta="Muay Thai", Fotografia="Bruce.jpg", ListaDeJogos = new List<Jogo>{ jogos[1], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=25, Nome="Jin Kazama", Origem="Jap�o", Estreia="Tekken 3", TipoLuta="Carat� de luta avan�ada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="Jin.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=26, Nome="Mokujin", Origem="Jap�o", Estreia="Tekken 3", TipoLuta="Mimicry", Fotografia="Mokujin.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[4], jogos[5], jogos[6], jogos[9], jogos[10] }},

                new Personagens {ID=27, Nome="Forest Law", Origem="USA", Estreia="Tekken 3", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Fotografia="ForestLaw.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=28, Nome="King II", Origem="Mexico", Estreia="Tekken 3", TipoLuta="Pro-Wrestling", Fotografia="KingII.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=29, Nome="Ling Xiaoyu", Origem="China", Estreia="Tekken 3", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Xiaoyu.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=30, Nome="Julia Chang", Origem="USA", Estreia="Tekken 3", TipoLuta="Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Julia.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[9], jogos[10] }},

                new Personagens {ID=31, Nome="Hwoarang", Origem="Coreia do Sul", Estreia="Tekken 3", TipoLuta="Taekwondo", Fotografia="Hwoarang.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=32, Nome="Eddy Gordo", Origem="Brasil", Estreia="Tekken 3", TipoLuta="Capoeira", Fotografia="Eddy.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=33, Nome="Bryan Fury", Origem="USA", Estreia="Tekken 3", TipoLuta="Kickboxing", Fotografia="Bryan.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=34, Nome="Kuma II", Origem="Irlanda", Estreia="Tekken 3", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="KumaII.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=35, Nome="Ogre", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Toshin", Fotografia="Ogre.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=36, Nome="True Ogre", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Desconhecida", Fotografia="TrueOgre.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=37, Nome="Panda", Origem="China", Estreia="Tekken 3", TipoLuta="Kuma Shinken estilo Heihachi", Fotografia="Panda.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[9], jogos[10] }},

                new Personagens {ID=38, Nome="Tiger Jackson", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Capoeira", Fotografia="TigerJackson.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[9], jogos[10] }},

                new Personagens {ID=39, Nome="Doctor Bosconovitch", Origem="Russia", Estreia="Tekken 3", TipoLuta="Tudo o que ele sabe", Fotografia="DoctorBosconovitch.jpg", ListaDeJogos = new List<Jogo>{ jogos[2], jogos[10] }},

                new Personagens {ID=40, Nome="Gon", Origem="Desconhecida", Estreia="Tekken 3", TipoLuta="Desconhecida", Fotografia="Gon.jpg", ListaDeJogos = new List<Jogo>{ jogos[2] }},

                new Personagens {ID=41, Nome="Christie Monteiro", Origem="Brasil", Estreia="Tekken 4", TipoLuta="Capoeira", Fotografia="Christie.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=42, Nome="Craig Marduk", Origem="Australia", Estreia="Tekken 4", TipoLuta="Vale Tudo", Fotografia="Marduk.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=43, Nome="Steve Fox", Origem="Reino Unido", Estreia="Tekken 4", TipoLuta="Box", Fotografia="Steve.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=44, Nome="Combot", Origem="Frabicado pela Violet Systems", Estreia="Tekken 4", TipoLuta="Mimicry", Fotografia="Combot.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[10] }},

                new Personagens {ID=45, Nome="Violet", Origem="Jap�o", Estreia="Tekken 4", TipoLuta="Artes marciais baseadas em Jeet Kune Do", Fotografia="Violet.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[8], jogos[10] }},

                new Personagens {ID=46, Nome="Miharu Hirano", Origem="Jap�o", Estreia="Tekken 4", TipoLuta="Baguazhang e Piguaquan baseados em artes marciais chinesas", Fotografia="Miharu.jpg", ListaDeJogos = new List<Jogo>{ jogos[3], jogos[10] }},

                new Personagens {ID=47, Nome="Feng Wei", Origem="China", Estreia="Tekken 5", TipoLuta="Artes marciais do estilo God Fist", Fotografia="Feng.jpg", ListaDeJogos = new List<Jogo>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=48, Nome="Asuka Kazama", Origem="Jap�o", Estreia="Tekken 5", TipoLuta="Artes marciais tradicionais estilo Kazama", Fotografia="Asuka.jpg", ListaDeJogos = new List<Jogo>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=49, Nome="Raven", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Ninjutsu", Fotografia="Raven.jpg", ListaDeJogos = new List<Jogo>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=50, Nome="Devil Jin", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Carat� de luta avan�ada estilo Mishima com artes marciais tradicionais estilo Kazama", Fotografia="DevilJin.jpg", ListaDeJogos = new List<Jogo>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=51, Nome="Roger Jr.", Origem="Desconhecida", Estreia="Tekken 5", TipoLuta="Commando Wrestling", Fotografia="RogerJr.jpg", ListaDeJogos = new List<Jogo>{ jogos[4], jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=52, Nome="Jinpachi Mishima", Origem="Jap�o", Estreia="Tekken 5", TipoLuta="Carat� de Combate estilo Mishima", Fotografia="Jinpachi.jpg", ListaDeJogos = new List<Jogo>{ jogos[5], jogos[10] }},

                new Personagens {ID=53, Nome="Armor King II", Origem="Irlanda", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Pro-Wrestling", Fotografia="ArmorKingII.jpg", ListaDeJogos = new List<Jogo>{ jogos[5], jogos[6], jogos[7], jogos[10] }},

                new Personagens {ID=54, Nome="Lili De Rochefort", Origem="Monaco", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Auto-ensinada", Fotografia="Lili.jpg", ListaDeJogos = new List<Jogo>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=55, Nome="Sergei Dragrunov", Origem="Russia", Estreia="Tekken 5: Dark Resurrection", TipoLuta="Commando Sambo", Fotografia="SergeiDragunov.jpg", ListaDeJogos = new List<Jogo>{ jogos[5], jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=56, Nome="Alisa Bosconovitch", Origem="Russia", Estreia="Tekken 6: Bloodline Rebellion", TipoLuta="Combate de alta mobilidade usando propulsores", Fotografia="Alisa.jpg", ListaDeJogos = new List<Jogo>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=57, Nome="Bob Richards", Origem="USA", Estreia="Tekken 6", TipoLuta="Karat� Freestyle", Fotografia="Bob.jpg", ListaDeJogos = new List<Jogo>{ jogos[6], jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=58, Nome="Lars Alexandersson", Origem="Su�cia", Estreia="Tekken 6: Bloodline Rebellion", TipoLuta="Karat� e Artes Marciais Tekken Forces", Fotografia="Lars.jpg", ListaDeJogos = new List<Jogo>{ jogos[7], jogos[8], jogos[10] }},

                new Personagens {ID=59, Nome="Leo Kliesen", Origem="Alemanha", Estreia="Tekken 6", TipoLuta="Baji Quan", Fotografia="Leo.jpg", ListaDeJogos = new List<Jogo>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=60, Nome="Miguel Rojo", Origem="Spain", Estreia="Tekken 6", TipoLuta="N�o definido (Luta de rua)", Fotografia="Miguel.jpg", ListaDeJogos = new List<Jogo>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=61, Nome="Zafina", Origem="Egipto", Estreia="Tekken 6", TipoLuta="Artes antigas de Assassinato", Fotografia="Zafina.jpg", ListaDeJogos = new List<Jogo>{ jogos[6], jogos[7], jogos[8], jogos[10] } },

                new Personagens {ID=62, Nome="Akuma", Origem="Jap�o", Estreia="Tekken 7", TipoLuta="Artes Marciais", Fotografia="Akuma.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=63, Nome="Claudio Serafino", Origem="It�lia", Estreia="Tekken 7", TipoLuta="Feiti�aria de Exorcismo estilo Sirius", Fotografia="Claudio.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=64, Nome="Geese Howard", Origem="USA", Estreia="Tekken 7", TipoLuta="Kobujutsu", Fotografia="Geese.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=65, Nome="Gigas", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Impulso Destrutivo", Fotografia="Gigas.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=66, Nome="Josie Rizal", Origem="Filipinas", Estreia="Tekken 7", TipoLuta="Kickboxing baseado em Eskrima", Fotografia="Josie.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=67, Nome="Katarina Alves", Origem="Brasil", Estreia="Tekken 7", TipoLuta="Savate", Fotografia="Katarina.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=68, Nome="Kazumi Mishima", Origem="Ar�bia Saudita", Estreia="Tekken 7", TipoLuta="Karat� estilo Hachijo misturado com Karat� de Combato estilo Mishima", Fotografia="Kazumi.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=69, Nome="Shaheen", Origem="Irlanda", Estreia="Tekken 2", TipoLuta="Estilo militar de combate", Fotografia="Shaheen.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=70, Nome="Master Raven", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Ninjutsu", Fotografia="MasterRaven.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=71, Nome="Noctis Lucis Caelum", Origem="Irlanda", Estreia="Tekken 7", TipoLuta="Weapon Summoning", Fotografia="Noctis.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=72, Nome="Lucky Chloe", Origem="Desconhecida", Estreia="Tekken 7", TipoLuta="Dan�a Freestyle e acrob�tica", Fotografia="LuckyChloe.jpg", ListaDeJogos = new List<Jogo>{ jogos[8] } },

                new Personagens {ID=73, Nome="Tetsujin", Origem="Desconhecida", Estreia="Tekken Tag Tournament", TipoLuta="Mimicry", Fotografia="Tetsujin.jpg", ListaDeJogos = new List<Jogo>{ jogos[9] } },

                new Personagens {ID=74, Nome="Unknown", Origem="Desconhecida", Estreia="Tekken Tag Tournament", TipoLuta="Mimicry",  Fotografia="Unknown.jpg", ListaDeJogos = new List<Jogo>{ jogos[9], jogos[10] } },

                new Personagens {ID=75, Nome="Jaycee", Origem="USA", Estreia="Tekken Tag Tournament 2", TipoLuta="Pro-Wrestling, Xin Yi Liu He Quan e Baji Quan baseados em artes marciais chinesas", Fotografia="Jaycee.jpg", ListaDeJogos = new List<Jogo> { jogos[10] } },

                new Personagens {ID=76, Nome="Sebastian", Origem="Monaco", Estreia="Tekken Tag Tournament 2", TipoLuta="Dan�a Freestyle e acrob�tica", Fotografia="Sebastian.jpg", ListaDeJogos = new List<Jogo>{ jogos[10] } },

                new Personagens {ID=77, Nome="Slim Bob", Origem="USA", Estreia="Tekken Tag Tournament 2", TipoLuta="Karat� estilo livre", Fotografia="SlimBob.jpg", ListaDeJogos = new List<Jogo>{ jogos[10] } },

};
            personagens.ForEach(aa => context.Personagens.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();



            // adiciona HISTORIA

            var historia = new List<Historia> {
           new Historia {ID=1, Nome="Tekken 1", Resumo="Um torneio mundial de artes marciais est� chegando ao fim, com uma grande quantia de pr�mios em dinheiro concedida ao lutador que derrotar Heihachi Mishima na rodada final da competi��o. O concurso � patrocinado pelo grupo financeiro gigante, o Mishima Zaibatsu. H� oito lutadores que permanecem ap�s vencerem as partidas de morte em todo o mundo, com o vencedor do torneio recebendo o t�tulo de Rei do Punho de Ferro. Apenas um ter� a chance de derrotar Heihachi e levar para casa o pr�mio em dinheiro e a fama. O jogador � inicialmente capaz de selecionar um desses oito lutadores, cada um com suas pr�prias raz�es pessoais para entrar no torneio, al�m do dinheiro do pr�mio. Kazuya Mishima � a personagem principal. Filho biol�gico de Heihachi, ele foi jogado em uma ravina pelo seu pai quando ele tinha cinco anos de idade. Heihachi, acreditando que seu filho era fraco demais para herdar seu conglomerado, decidiu que, se fosse realmente forte o suficiente, seria capaz de sobreviver � queda e subir de volta. Kazuya mal sobreviveu a uma queda que o deixou com a cicatriz vis�vel em seu peito. Alimentado pelo �dio por seu pai, ele entra no torneio para se vingar.",JogoFK=1},
           new Historia {ID=2, Nome="Tekken 2", Resumo="Um torneio mundial de artes marciais estava a chegar ao final. Uma grande quantia de pr�mios em dinheiro, que deveria ser concedida ao lutador que poderia derrotar Heihachi Mishima na rodada final, forneceu um incentivo para os guerreiros de todo o mundo. Financiado e patrocinado pelo grupo financeiro gigante, o Mishima Zaibatsu, o primeiro torneio de Tekken come�ou com oito lutadores, todos os quais sa�ram vitoriosos de v�rios jogos realizados em todo o mundo, reunidos por diferentes motivos, todos possuindo a habilidade e o poder necess�rios para vit�ria. Muitas batalhas foram travadas, mas apenas um guerreiro solit�rio emergiu com o direito de desafiar Heihachi Mishima para o t�tulo de King of Iron Fist. Este guerreiro era Kazuya Mishima, o filho de sangue frio de Heihachi. Tendo a cicatriz dada a ele por seu pai, ele entra em combate vicioso com Heihachi no mesmo campo onde ele foi derrubado e caiu de um penhasco aos cinco anos de idade. Depois de uma dura batalha que durou horas, Kazuya saiu vitorioso, utilizando o poder concedido a ele pela entidade sobrenatural conhecida como Diabo. Dois anos se passaram. Mishima Zaibatsu, sob a lideran�a de Kazuya, tornou-se ainda mais poderoso, com os seus tent�culos chegando a todos os cantos do mundo. Logo ap�s a aparente morte do seu pai, Kazuya desaparece nas sombras. No entanto, rumores de seu imenso poder e um lado sombrio, lentamente come�am a se espalhar por todo o mundo. Dois anos ap�s o final do primeiro torneio, uma mensagem � transmitida da fortaleza Mishima Zaibatsu para ag�ncias de not�cias de todo o mundo anunciando um segundo torneio com um pr�mio mil vezes maior do que o primeiro. Como seu filho antes dele, Heihachi sobreviveu � queda na ravina gra�as � sua super-humana resili�ncia. Ele ent�o recuou para as colinas para meditar, a fim de reavivar e aumentar sua capacidade de lutar. Ele entra no Torneio King of Iron Fist 2 para recuperar seu conglomerado e se livrar de Kazuya de uma vez por todas.",JogoFK=2},
           new Historia {ID=3, Nome="Tekken 3", Resumo="Decorridos dezesseis anos ap�s o segundo Torneio King of Iron Fist, a hist�ria come�a com Jun Kazama, que vive uma vida tranquila em Yakushima com seu filho, Jin, filho de Kazuya Mishima. Heihachi Mishima, entretanto, estabeleceu a Tekken Force, uma organiza��o dedicada � prote��o do Mishima Zaibatsu. Usando a influ�ncia da empresa, Heihachi � respons�vel por muitos eventos que levaram � paz mundial. No entanto, enquanto em uma escava��o no M�xico, um esquadr�o da For�a Tekken de Heihachi � atacado e derrotado por um ser misterioso. O �nico soldado sobrevivente consegue transmitir uma breve mensagem a Heihachi, descrevendo o perpetrador como um 'Ogro' ou um 'Deus Lutador'. Heihachi e uma equipe de soldados investigam, com Heihachi conseguindo vislumbrar o culpado. Depois de ver o personagem Ogre, o sonho h� muito adormecido de Heihachi de dom�nio mundial � despertado. Ele procura capturar Ogre para us�-lo para este objetivo. Logo depois, v�rios mestres de artes marciais come�am a desaparecer de todo o mundo, e Heihachi est� convencido de que isso � obra de Ogre. Em Yakushima, Jun come�a a sentir a presen�a de Ogre se aproximando dela e de Jin. Sabendo que ela se tornou um alvo, Jun conta a Jin sobre Ogre, e o instrui a ir direto para Heihachi caso algo aconte�a. Algum tempo depois do d�cimo quinto anivers�rio de Jin, Ogre de fato ataca. Contra os desejos de Jun, Jin valentemente tenta lutar contra Ogre para proteger sua amada m�e, mas Ogre o afasta e o deixa inconsciente. Quando Jin desperta, ele descobre que a casa foi queimada at� o ch�o e que sua m�e est� desaparecida e provavelmente morta. Guiado pela vingan�a, Jin vai at� Heihachi e conta tudo. Jin implora a Heihachi para trein�-lo para se tornar forte o suficiente para enfrentar Ogre novamente. Heihachi aceita e revela ser um professor confi�vel para Jin. Quatro anos depois, Jin se torna um lutador impressionante e mestre do Karate estilo Mishima. No anivers�rio de dezenove anos de Jin, o King of Iron Fist Tournament 3 � anunciado, e Jin se prepara para sua pr�xima batalha contra Ogre. Ele n�o sabe, no entanto, que Heihachi est� meramente usando ele e o resto dos concorrentes como isca para atrair Ogre para captur�-lo. Eventualmente, o torneio leva ao confronto final entre Jin e o Deus da Luta. Ogre � capaz de se transformar em uma forma verdadeira muito mais poderosa. Jin surge o vencedor e Ogre se dissolve completamente. Momentos depois, Jin � morto a tiros por uma esquadra de Tekken Forces liderada por Heihachi, que, n�o precisando mais de Jin, termina o trabalho pessoalmente dando um tiro final na cabe�a de seu neto. No entanto, Jin, revivido pelo Gene Diabo dentro dele (porque depois que a m�e de Jin desapareceu ap�s um ataque de Ogre, Devil voltou, marcou o bra�o esquerdo de Jin com uma marca, o possuindo), desperta e faz o trabalho r�pido dos soldados, sua aten��o para Heihachi e, literalmente, esmagando-o atrav�s da parede do templo. Heihachi sobrevive a longa queda, mas Jin, no ar, brota asas negras e emplumadas e ataca Heihachi uma �ltima vez. Ele ent�o voa para a noite, deixando seu av� perplexo olhando para ele.",JogoFK=3},
           new Historia {ID=4, Nome="Tekken 4", Resumo="Dois anos atr�s, Heihachi Mishima n�o conseguiu capturar Ogre. N�o querendo desistir, Heihachi ordenou que seus pesquisadores coletassem amostras de sangue, tecido da pele e fragmentos de cascos deixados por Ogre (ou conhecido como True Ogre em sua verdadeira manifesta��o) para realizar experimentos gen�ticos. O objetivo de Heihachi era criar uma nova forma de vida ao unir o genoma de Ogre com o seu. No entanto, a pesquisa n�o teve sucesso. Ap�s uma extensa experimenta��o, os bioengenheiros de Heihachi chegaram � conclus�o de que um gene adicional - o Gene do diabo - era necess�rio a fim de unir com sucesso o c�digo gen�tico de Ogre em outro organismo vivo. Heihachi aprendeu que seu pr�prio genoma n�o tinha o Gene do Diabo, mas ele conhecia algu�m que tinha, Jin Kazama. Heihachi procurou por Jin sem sucesso. No entanto, Heihachi descobriu uma fotografia durante sua investiga��o que despertou sua curiosidade. A foto de 20 anos era uma imagem de um cad�ver queimado coberto de feridas de lacera��o. Heihachi deu uma aten��o especial �s costas do cad�ver, que tinham o que pareciam deformados, protuberantes membros de asas. Convencido de que a foto era de Kazuya, seu pr�prio filho, que ele jogou em um vulc�o 20 anos atr�s, Heihachi desviou todos os seus recursos para uma busca pelo corpo. Essa busca levou Heihachi � G Corporation, uma empresa de biotecnologia de ponta que fez avan�os sem precedentes no campo da pesquisa em biogen�tica. Heihachi descobriu que a G Corporation encontrou o cad�ver e extraiu e analisou seus dados gen�ticos. Na verdade, Heihachi aprendeu que a empresa estava no meio de criar uma nova forma de vida usando os dados. Heihachi tamb�m determinou que os restos e dados de pesquisa de Kazuya estavam garantidos nos laborat�rios de pesquisa de Nebraska e Nepal da G Corporation, respectivamente. A For�a Tekken invadiu o laborat�rio de pesquisa de seguran�a m�xima da G Corporation no Nepal. Quando entraram, uma silhueta de uma grande figura emergiu lentamente da sala. Quando Heihachi p�de ver claramente, ele imediatamente reconheceu a figura grande como Kazuya. Kazuya foi ressuscitado no centro de pesquisa da G Corporation. Depois de sua ressurrei��o, Kazuya ofereceu seu corpo como material de pesquisa para determinar a verdadeira natureza do Diabo que residia dentro dele. O objetivo de Kazuya era unificar seus dois eus em um. Kazuya teorizou que se ele unisse seu corpo com o Diabo, ele seria capaz de realmente aproveitar seus poderes. Ele poderia finalmente se vingar de Heihachi e do Mishima Zaibatsu. Enfurecido por Heihachi ter frustrado seus planos, Kazuya destruiu a fortemente armada For�a Tekken e desapareceu nas chamas dos destro�os do laborat�rio. O Mishima Zaibatsu anunciou o Torneio King of Iron Fist 4 e colocou o enorme imp�rio financeiro como o principal pr�mio. O campe�o que conseguir derrotar Heihachi no final do Torneio herdar� o Mishima Zaibatsu. Kazuya e Jin chegam � final. Jin quase mata Kazuya. Heihachi decide lutar contra Jin. e tomar seu Gene do Diabo para si mesmo. No entanto, ele tamb�m foi derrotado por Jin. Jin se transformou em sua forma Diabo e mais uma vez, ele voou para a noite, sem deixar nenhum sinal de perigo em lugar algum.",JogoFK=4},
           new Historia {ID=5, Nome="Tekken 5", Resumo="De repente, um monte de rob�s Jack-4 interrompe a batalha. Tanto Kazuya quanto Heihachi est�o surpresos com o ataque e come�am a lutar em equipe contra a invas�o. Durante a batalha, no entanto, Kazuya trai seu pai, jogando-o no caminho do ex�rcito de rob�s e fugas. Segundos depois, o rob� explode, destruindo Hon-Maru. Um personagem misterioso, Raven, assistindo no topo do penhasco, fala em um fone de ouvido e relata: 'Heihachi Mishima est� morto'. Enquanto isso, Devil Gene, de Jin Kazama, enlouquece e decide procurar o respons�vel pela mudan�a ao entrar no torneio. Kazuya tamb�m entra para descobrir exatamente quem na G Corporation enviou o Jack-4 para mat�-lo e se vingar. Enquanto Jin e Kazuya avan�am no torneio, o patrocinador secreto � finalmente revelado: Jinpachi Mishima, o pai de Heihachi e que est� desaparecido h� cinquenta anos. Como resultado, Jinpachi � o fundador do Mishima Zaibatsu e era um respeitado mestre de artes marciais at� que seu ganancioso filho Heihachi roubou a companhia dele e o prendeu debaixo de Hon-Maru depois que Jinpachi tentou um golpe de estado (Heihachi). estava dirigindo a empresa para a ind�stria militar, algo que Jinpachi acreditava que n�o estava certo). Jinpachi morreu logo depois da fome at� que uma entidade misteriosa tomou conta de sua mente e lhe concedeu a imortalidade, e Jinpachi foi finalmente libertado de sua pris�o quando o Jack-4 destruiu Hon-Maru. A partir de agora, a entidade misteriosa est� lentamente consumindo a mente de Jinpachi, e Jinpachi anunciou o torneio na esperan�a de que algu�m o mate e acabe com seu reinado de terror antes mesmo de come�ar. No final, Jin chega � final e enfrenta seu bisav� em combate. Em �ltima an�lise, Jin consegue derrotar Jinpachi, que se dissolve em p� e desaparece, cumprido seu desejo. Jin � agora o novo dono do Mishima Zaibatsu.",JogoFK=5},
           new Historia {ID=6, Nome="Tekken 5: Dark Resurrection", Resumo="O jogo segue exatamente o mesmo enredo de Tekken 5, apenas com as adi��es de dois novos personagens e um personagem que retorna; Emilie 'Lili' De Rochefort (que procura destruir o Mishima Zaibatsu e acabar com o problema financeiro de seu pai), Sergei Dragunov (um membro de Spetsnaz que foi enviado para capturar Jin) e Armor King II (que foi pensado para ter sido morto antes os eventos de Tekken 4 e cuja identidade e objetivos permanecem um mist�rio para o jogador).",JogoFK=6},
           new Historia {ID=7, Nome="Tekken 6", Resumo="Ap�s a sua vit�ria no torneio anterior, Jin Kazama, o Rei do Punho de Ferro, assumiu o Mishima Zaibatsu e agora parece possuir ambi��es tir�nicas. Usando seus recursos dentro da organiza��o para se tornar uma superpot�ncia global, ele separa os la�os nacionais do Mishima Zaibatsu e abertamente declara guerra contra todas as na��es no ano seguinte. Essa a��o mergulha o mundo em uma espiral extremamente ca�tica, com uma guerra civil em grande escala em erup��o ao redor do globo e at� mesmo em meio �s col�nias espaciais que orbitam o planeta. Seu pai biol�gico, Kazuya Mishima, est� ciente disso e acha que a interfer�ncia de Jin em seus pr�prios planos de domina��o global � um inc�modo. Agora no comando da G Corporation, tendo usurpado e assumido a empresa ap�s a falha de seus l�deres anteriores em us�-lo, Kazuya � visto como a �nica for�a que poderia se opor a Jin e colocar uma recompensa na cabe�a de Jin por qualquer um que pode captur�-lo. A resposta de Jin � anunciar o Torneio King of Iron Fist 6 para lutar contra Kazuya e esmagar a G Corporation. Enquanto isso, entre as fileiras da For�a Tekken, um jovem soldado chamado Lars Alexandersson iniciou uma rebeli�o para desmantelar lentamente a Mishima Zaibatsu e a G Corporation a fim de p�r fim � guerra. Durante uma opera��o, Lars se depara com um jovem andr�ide identificando-a como Alisa Bosconovitch. As for�as da G Corporation logo atacam, iniciando uma luta e causando uma explos�o que mata quase todos os presentes no local e deixa Lars com amn�sia. Lars foge com Alisa e os dois come�am uma jornada para descobrir suas origens, encontrando e lutando contra v�rios personagens anteriores de Tekken. Jin junto com seus principais subordinados, Nina Williams e Eddy Gordo, aprendem isso e fazem uma ca�ada a Lars. Durante a jornada, Lars se re�ne com seu tenente, Tougou, e os dois mant�m contato. Gradualmente, Lars come�a a se recuperar de sua amn�sia e lembra que ele � o filho ileg�timo de Heihachi Mishima, agora vivendo na solid�o, mas ainda planejando retomar o Zaibatsu de Jin. Lars localiza e confronta Heihachi, preparado para mat�-lo, mas cede no �ltimo minuto e sai, recusando a proposta de Heihachi de que eles trabalhem juntos para derrotar Jin. Lars eventualmente entra em contato com Lee Chaolan, que serve como aux�lio e contato para Lars depois que Lars resgata a amiga de Lee, Julia Chang, de uma instala��o da G Corporation. Ao mesmo tempo, Kazuya ouve as fa�anhas de Lars e envia seus homens para mat�-lo. A jornada de Lars e Alisa finalmente os leva � G Corporation, onde eles s�o confrontados por um esquadr�o de soldados armados. Tougou e seus homens chegam para fornecer apoio para Lars enquanto Lars e Alisa enfrentam e derrotam Anna Williams. Uma vez que eles encontram Kazuya, eles o envolvem em combate, mas s�o derrotados e n�o conseguem apreend�-lo; resultando em sua fuga. Depois, Lars e Alisa conseguem escapar, mas Tougou � morto em batalha, e Lars promete ving�-lo. Eles ent�o seq�estram um trem do metr� Zaibatsu para chegar � Torre Central do Mishima Zaibatsu, embora eles sejam emboscados pelo caminho de Nina e um esquadr�o das For�as Tekken. Apesar das probabilidades, Lars derrota os soldados e chuta Nina fora do trem. Nina depois reaparece depois de ter sobrevivido ao outono, mas � novamente derrotada por Lars. Lars e Alisa alcan�am a torre e confrontam Jin e lutam contra ele, que n�o chega a nenhuma conclus�o. Em uma reviravolta na hist�ria, Jin reinicia o banco de mem�ria de Alisa e a coloca em Lars, revelando que ela foi constru�da o tempo todo para proteg�-lo e que ele a estava usando para monitorar as a��es de Lars, embora o ataque n�o fizesse parte do plano de Jin. . Lars luta e consegue derrotar Alisa, que foge da cena. Raven de repente chega, tendo seguido Lars e Alisa ao longo de sua jornada, e oferece ajuda, quando ele v� Jin indo para o deserto. Lars aceita. Lars e Raven localizam um templo abandonado no meio do deserto, que dizem ser a casa do dem�nio conhecido como Azazel, ou o Retificador. Dentro do templo, Lars e Raven encontram e confrontam Kazuya mais uma vez, o �ltimo tamb�m aprende, para seu desgosto, que Lars � seu meio-irm�o. Ap�s a luta, Kazuya deixa o templo com Anna. Lars e Raven chegam ao cora��o do templo e localizam Azazel. Durante a luta, Azazel diz a Lars que ele � apenas uma cria��o do homem, e que � hora de destruir a humanidade para faz�-los expiar seus pecados, mas como ele est� muito ferido para continuar lutando, Azazel aparentemente se auto-destr�i. Lars e Raven fogem do templo quando ele desmorona. Uma vez fora, eles s�o confrontados por Jin mais uma vez, que coloca Alisa neles. Lars Alexandersson e Raven derrotam Alisa, que retorna ao seu antigo eu e compartilha um breve e choroso encontro com Lars antes de morrer. Jin Kazama insulta Alisa, enfurecendo Lars e iniciando outra luta. Lars luta contra ele e derrota Jin em f�ria. Jin, ofegante, finalmente revela as reais inten��es por tr�s de suas a��es: sabendo sobre Azazel h� muito tempo desde a hist�ria de Zafina, Jin sabia que a �nica maneira de despertar Azazel era encher o mundo de emo��es negativas, e a melhor maneira era come�ar um guerra. Jin tamb�m diz a Lars que ele nunca apreciou como as pessoas do mundo tinham que viver sob o governo opressivo de governos e corpora��es gananciosas, e iniciando a guerra, esses poderes se desintegrariam em nada, e o mundo finalmente veria liberdade e paz. Jin tamb�m diz a Lars que Azazel ainda n�o est� morto e s� pode ser destru�do por algu�m que carrega o Gene do Diabo. Uma vez que a besta � derrotada, Jin pode matar seus pr�prios dem�nios internos, libertando-se de Gene. Azazel, agora muito mais forte, repentinamente irrompe dos escombros, mas Jin, se fortalecendo com o Gene do Diabo, se aproxima de Azazel, imune a seus ataques, e d� um soco direto no peito da fera, fazendo com que os dois caiam � sua aparente mortes. Lars diz a Jin para parar, mas j� era tarde demais, j� que Jin n�o tinha escutado. Ent�o, um raio de luz brilhante dispara, indicando que Azazel havia morrido. Nina aparece e compartilha uma breve conversa com Lars, declarando que ela n�o pode julgar se as a��es de Jin estavam certas ou erradas. Lars e Raven levam o corpo de Alisa para Lee, que promete repar�-la o mais r�pido poss�vel. Lars se despede de Raven. Lars ent�o recebe uma liga��o oferecendo-lhe um novo emprego. A conversa telef�nica � um mist�rio para o jogador. Uma cena p�s-cr�ditos mostra que Raven e seus colegas encontraram o corpo semi-enterrado de Jin no deserto. A tatuagem ainda � vis�vel no bra�o de Jin, indicando que a morte de Azazel n�o libertou Jin do Gene do Diabo, e os eventos mais tarde v�o para o pr�ximo jogo.",JogoFK=7},
           new Historia {ID=8, Nome="Tekken 6: Bloodline Rebellion", Resumo="Tem o mesmo enredo do Tekken 6.",JogoFK=8},
           new Historia {ID=9, Nome="Tekken 7", Resumo="Ap�s os eventos de Tekken 6, a guerra entre o Mishima Zaibatsu e a G Corporation ainda continua junto com o desaparecimento de Jin Kazama. Enquanto isso, um jornalista investigativo que perdeu sua esposa e filho durante a guerra que Jin iniciou (e que tamb�m narra em parte do jogo) come�a a narrar sobre Mishima Zaibatsu e G Corporation.40 anos atr�s, Kazuya Mishima � mostrado lutando contra seu pai, Heihachi Mishima quando de repente ele � violentamente expulso por Heihachi. Kazuya est� enfurecido porque Heihachi matou sua m�e Kazumi Mishima ne� Hachijo. Heihachi bate em Kazuya e joga-o para fora do penhasco, colocando os jogos de Tekken em movimento. Heihachi Mishima encontra e alcan�a o edif�cio Mishima Zaibatsu e recupera o controle ap�s derrotar Nina. Ele anuncia o torneio The King of Iron Fist. Heihachi e Nina Williams fazem um acordo com Claudio Serafino, que � o l�der da organiza��o Sirius Marksmen, para expor Kazuya Mishima, o l�der da corpora��o G, pois ele possui o Gene Diabo e para transformar a opini�o p�blica contra eles. Claudio concorda e sente uma for�a que n�o tem qualquer rela��o com Jin ou Kazuya. Em outro lugar, o rep�rter procura informa��es e encontra algo sobre a hist�ria de Mishimas e re�ne o fato de que o pai de Heihachi, Jinpachi Mishima foi preso sob Hon-Maru e a morte de sua esposa, Kazumi Mishima ne� Hachijo aconteceu no mesmo ano de Heihachi jogando um Kazuya de cinco anos de idade em um penhasco. Mais tarde, as Na��es Unidas conseguem encontrar um Jin enfraquecido, mas n�o antes de ele se transformar em dem�nio e ataques, mais tarde Jin escapa e � quase capturado, mas n�o antes de Lars Alexandersson encontr�-lo e tirar os soldados, ele pega Jin e dirige longe. Ele o leva para a Violet Systems, onde Jin se recupera ap�s o ataque. Lee Chaolan, o l�der da Violet Systems, conserta Alisa Bosconovitch, aparentemente destru�da no �ltimo jogo. O rep�rter, tendo se encontrado com Lars e Lee durante suas descobertas, mataria Jin em seu sono, mas Lars o desencoraja, dizendo que ele tamb�m quer matar Jin, mas ele � o �nico que tem a chance de parar o conflito com Kazuya. e Heihachi. Heihachi est� meditando em um templo quando, de repente, as portas se abrem violentamente quando Akuma � revelado, Heihachi e Akuma lutam apenas por rob�s Jack-6 e s�o derrotados pelos dois. Heihachi pergunta quem � o dem�nio, Akuma diz a ele seu nome e que ele foi enviado por Kazumi antes de sua morte para matar Heihachi e Kazuya. Kazuya, sem saber que o par est� ouvindo isso de um dos rob�s Jack-6, Heihachi e Akuma se enfrentam novamente com Akuma aparentemente matando Heihachi, que escapa depois e declara-se morto para o p�blico. A For�a Tekken invade e Nina tenta levar Jin, mas � interrompida pela Alisa agora consertada. Nina consegue capturar Jin, mas quando ela entra em contato com as pessoas no helic�ptero, a voz de Lee pode ser ouvida quando os soldados da For�a Tekken caem e Lee controla o helic�ptero, Lee, Lars e Alisa acabam se afastando da For�a Tekken e resgatam Jin. ocupado.Akuma depois aparece e os soldados da Corpora��o G t�m suas armas treinadas nele. Kazuya, no entanto, diz-lhes para lev�-lo para o telhado, Kazuya pergunta como ele conhece sua m�e, Akuma responde que ele tem uma d�vida com Kazumi porque ela salvou sua vida. Eles lutam e Kazuya se transforma em sua forma demon�aca, Heihachi consegue capturar Kazuya se transformando em sua forma demon�aca. Akuma e Kazuya lutam contra o pr�dio em que estavam sendo destru�dos por Heihachi usando um feixe de espa�o. A not�cia se espalhou sobre o avistamento de um dem�nio que, segundo rumores, era Kazuya. O rep�rter menciona como ele pensou que sua cidade foi destru�da por seres humanos, mas ele acha que havia mais do que isso. Kazuya retalia disparando o feixe que Heihachi atirou, o que resulta na queda na terra. O rep�rter ent�o tenta contar ao Mishima Zaibatsu sobre sua nova finalidade, mas para sua surpresa, Heihachi quer se encontrar com o rep�rter. Heihachi conta a ele sobre Kazumi e sobre como eles se conheceram, quando um dia Kazumi ficou com febre e se recuperou, no dia seguinte Kazumi confrontou Heihachi quando estava treinando e disse a ele que um dia infligiria guerra a outros e brigas, durante o treinamento. lutar ele se transforma em sua forma demon�aca. Heihachi bate nela e vai embora, Kazumi se levanta para outro ataque quando Heihachi a agarra pela garganta e esmaga sua laringe, matando-a. Heihachi ent�o disse ao jornal que ele jogou Kazuya de um penhasco porque queria ver se ele poderia voltar e se tornar o herdeiro do Mishima Zaibatsu. Heihachi ent�o diz que � culpa dele pelas mortes de sua fam�lia. O rep�rter pergunta a ele como ele sabe antes de ser agarrado por soldados Tekken, o rep�rter pergunta o que esta guerra significa para Heihachi apenas para Heihachi se afastar e o rep�rter ser nocauteado pelos soldados Tekken. Quando ele acorda, v� Lars que lhe diz que o Zaibatsu lhe disse para vir e eles voltam para a Violet Systems, o rep�rter estava pensando sobre o que Heihachi disse e o olhar que Heihachi deu a ele. Eles chegam a Violet Systems algumas horas depois, apenas para ver a vista de um vulc�o onde Kazuya e Heihachi lutam em uma TV que deixou o rep�rter em estado de choque. Kazuya e Heihachi est�o em um vulc�o onde planejam lutar, Heihachi come�a a derrotar Kazuya, antes de Kazuya se transformar em sua forma Devil Gene novamente. Eles lutam e Kazuya e Heihachi come�am a dar socos um no outro, Kazuya d� um soco no peito de Heihachi e assiste Kazuya dar uma cabe�ada em Heihachi. Kazuya mal consegue ficar de p�, ele v� flashbacks de tudo que aconteceu com ele, vendo como seu pai o jogou de um penhasco. que seu pai matou sua m�e nos jogos antes e depois. Kazuya fica bravo e acerta Heihachi com um forte soco que p�ra o cora��o de Heihachi, fazendo com que Heihachi caia no ch�o e morra. Kazuya joga o corpo sem vida de Heihachi no vulc�o com Kazuya dizendo aquelas palavras: 'Uma luta � sobre quem fica de p�. Nada mais'. No entanto, Kazuya percebe que Akuma tamb�m n�o est� morto, pois ele se esquiva do Gohadoken de Akuma e prossegue para combat�-lo em sua forma demon�aca. Quando o vulc�o come�ou a explodir quando o Devil Blaster de Devil Kazuya e o Messatsu Gohadoken de Akuma entraram em confronto, o resultado final da luta � desconhecido. Em outras partes da tarde, Lars, Alisa e Lee s�o vistos no telhado, observando as ru�nas do mundo sem Heihachi desde a queda de Mishima Zaibatsu, e concluindo que a G Corporation n�o far� nada para impedir a guerra de crise. Logo, Lars despacha seu sobrinho despertado, Jin como sua �ltima esperan�a de eliminar Kazuya para sempre e compensar a maior parte dos pecados remanescentes de seu sobrinho e o que Jin fez com o mundo desde o jogo anterior, como Jin cumpre, devido a o sangue do diabo que corre em suas veias como seu pai e que cabe a ele salvar o mundo, matar Kazuya e acabar com essa guerra de uma vez por todas.",JogoFK=9},
           new Historia {ID=10, Nome="Tekken Tag Tournament", Resumo="N�o tem.",JogoFK=10},
           new Historia {ID=11, Nome="Tekken Tag Tournament 2", Resumo="N�o tem.",JogoFK=11},
};
            historia.ForEach(bb => context.Historia.AddOrUpdate(b => b.ID, bb));
            context.SaveChanges();


        }
    }
}
