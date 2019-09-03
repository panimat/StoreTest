using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using POSStore.Data.Model;

namespace POSStore.Data
{
    public class DBObject
    {
        public static void Initial(AppDBInfo content)
        {
            if (!content.Category.Any())            
                content.Category.AddRange(Categories.Select(cont => cont.Value));
            
            if (!content.Product.Any())
            {
                content.AddRange(
                    new Product
                    {
                        //id = 1,
                        name = "MappleTouch",
                        description = "blablabla",
                        img = "/images/mapletouch.jpg",
                        price = 1000,
                        isAvailable = true,
                        isMostPopular = true,
                        Categ = Categories["POS терминалы"]
                    },
                    new Product
                    {
                        //id = 2,
                        name = "BTP",
                        description = "blablabla",
                        img = "/images/BTP.jpg",
                        price = 200,
                        isAvailable = true,
                        Categ = Categories["POS принтеры"]
                    },
                    new Product
                    {
                        //id = 2,
                        name = "EPSON",
                        description = "blablabla",
                        img = "/images/EPSON.jpg",
                        price = 200,
                        isAvailable = true,
                        isMostPopular = true,
                        Categ = Categories["POS принтеры"]
                    },
                    new Product
                    {
                        //id = 2,
                        name = "Rongta",
                        description = "blablabla",
                        img = "/images/rongta.jpg",
                        price = 200,
                        isAvailable = true,
                        Categ = Categories["POS принтеры"]
                    },
                    new Product
                    {
                        //id = 2,
                        name = "SAM4S",
                        description = "blablabla",
                        img = "/images/sam4s.jpg",
                        price = 200,
                        isAvailable = true,
                        Categ = Categories["POS принтеры"]
                    },
                    new Product
                    {
                        //id = 2,
                        name = "UP-88",
                        description = "blablabla",
                        img = "/images/rongta.jpg",
                        price = 200,
                        isAvailable = true,
                        isMostPopular = true,
                        Categ = Categories["POS принтеры"]
                    },
                    new Product
                    {
                        //id = 1,
                        name = "Elo",
                        description = "blablabla",
                        img = "/images/Elo.jpg",
                        price = 1000,
                        isAvailable = true,
                        Categ = Categories["POS терминалы"]
                    },
                    new Product
                    {
                        //id = 1,
                        name = "SPARK",
                        description = "blablabla",
                        img = "/images/SPARK.jpg",
                        price = 1000,
                        isAvailable = true,
                        isMostPopular = true,
                        Categ = Categories["POS терминалы"]
                    },
                    new Product
                    {
                        //id = 1,
                        name = "SUNMI",
                        description = "blablabla",
                        img = "/images/SUNMI.jpg",
                        price = 1000,
                        isAvailable = true,
                        Categ = Categories["POS терминалы"]
                    },
                    new Product
                    {
                        //id = 1,
                        name = "UNIQ",
                        description = "blablabla",
                        img = "/images/UNIQ.jpg",
                        price = 1000,
                        isAvailable = true,
                        isMostPopular = true,
                        Categ = Categories["POS терминалы"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> categDict;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categDict == null)
                {
                    var list = new Category[]
                    {
                        new Category
                        {
                            //id = 1, 
                            name = "POS терминалы"
                        },
                        new Category
                        {
                            //id = 2,
                            name = "POS принтеры"
                        }
                    };

                    categDict = new Dictionary<string, Category>();

                    foreach (var x in list)
                        categDict.Add(x.name, x);
                }

                return categDict;
            }
        }
    }
}
