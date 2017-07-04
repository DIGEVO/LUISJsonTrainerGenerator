using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUISJsonTrainerGenerator
{
    class Program
    {
        static List<string> intents = new List<string>() { "comparar", "conocer" };
        static Dictionary<string, List<string>> entities = new Dictionary<string, List<string>>()
            {
                { "indicador", new List<string>()
                    {
                        "uf",
                        "unidad de fomento",

                        "ivp",
                        "indice de valor promedio",

                        "dolar observado",
                        "dolar",

                        "dolar intercambio",
                        "dolar acuerdo",

                        "euro",

                        "ipc",
                        "indice de precios al consumidor",
                        "precios",

                        "utm",
                        "unidad tributaria mensual",
                        "impuestos",

                        "imacec",

                        "tpm",
                        "tasa politica monetaria",

                        "libra cobre",
                        "libra de cobre",
                        "cobre",

                        "tasa desempleo",
                        "tasa de desempleo",
                        "desempleo"
                    }
                },
                {"adjetivo_tiempo", new List<string>()
                    {
                        "proximo",
                        "proximos",
                        "siguiente",
                        "siguientes",
                        "pasado",
                        "pasados",
                        "pasada",
                        "pasadas"
                    }
                },
                { "fecha_relativa_corta", new List<string>()
                    {
                        "antier",
                        "anteayer",
                        "antes de ayer",
                        "ayer",
                        "hoy",
                        "mañana"
                    }
                },
                { "medida_tiempo", new List<string>()
                    {
                        "dia",
                        "dias",
                        "semana",
                        "semanas",
                        "mes",
                        "meses",
                        "año",
                        "años"
                    }
                },
                { "dia_semana", new List<string>()
                    {
                        "lunes",
                        "martes",
                        "miercoles",
                        "jueves",
                        "viernes",
                        "sabado",
                        "domingo"
                    }
                },
                { "tiempo_relativo",new List<string>()
                    {
                        "dentro de",
                        "respecto",
                        "con respecto"
                    }
                },
                { "fecha", new List<string>()
                {
                    "lunes",
                    "martes",
                    "miercoles",
                    "jueves",
                    "viernes",
                    "sabado",
                    "domingo",
                    "enero",
                    "febrero",
                    "marzo",
                    "abril",
                    "mayo",
                    "junio",
                    "julio",
                    "agosto",
                    "septiembre",
                    "octubre",
                    "noviembre",
                    "diciembre",
                    "anteayer",
                    "antesdeayer",
                    "antier",
                    "ayer",
                    "hoy",
                    "mañana",
                    "pasado mañana",
                    "proximo lunes",
                    "proximo martes",
                    "proximo miercoles",
                    "proximo jueves",
                    "proximo viernes",
                    "proximo sabado",
                    "proximo domingo",
                    "proximo enero",
                    "proximo febrero",
                    "proximo marzo",
                    "proximo abril",
                    "proximo mayo",
                    "proximo junio",
                    "proximo julio",
                    "proximo agosto",
                    "proximo septiembre",
                    "proximo octubre",
                    "proximo noviembre",
                    "proximo diciembre",
                    "pasado lunes",
                    "pasado martes",
                    "pasado miercoles",
                    "pasado jueves",
                    "pasado viernes",
                    "pasado sabado",
                    "pasado domingo",
                    "pasado enero",
                    "pasado febrero",
                    "pasado marzo",
                    "pasado abril",
                    "pasado mayo",
                    "pasado junio",
                    "pasado julio",
                    "pasado agosto",
                    "pasado septiembre",
                    "pasado octubre",
                    "pasado noviembre",
                    "pasado diciembre",
                    "proxima semana",
                    "proximo mes",
                    "proximo año",
                    "pasadas emana",
                    "pasado mes",
                    "pasado año",
                    "siguiente semana",
                    "siguiente mes",
                    "siguiente año",
                    "siguiente lunes",
                    "siguiente martes",
                    "siguiente miercoles",
                    "siguiente jueves",
                    "siguiente viernes",
                    "siguiente sabado",
                    "siguiente domingo",
                    "siguiente enero",
                    "siguiente febrero",
                    "siguiente marzo",
                    "siguiente abril",
                    "siguiente mayo",
                    "siguiente junio",
                    "siguiente julio",
                    "siguiente agosto",
                    "siguiente septiembre",
                    "siguiente octubre",
                    "siguiente noviembre",
                    "siguiente diciembre"
                }
                }
            };
        static void Main(string[] args)
        {
            //var l1 = new List<string>()
            //{
            //    "lunes",
            //    "martes",
            //    "miercoles",
            //    "jueves",
            //    "viernes",
            //    "sabado",
            //    "domingo",
            //    "enero",
            //    "febrero",
            //    "marzo",
            //    "abril",
            //    "mayo",
            //    "junio",
            //    "julio",
            //    "agosto",
            //    "septiembre",
            //    "octubre",
            //    "noviembre",
            //    "diciembre",
            //};

            //var l2 = new List<string>()
            //{
            //    "siguiente"
            //    //"proximo", "pasado"
            //};

            //l2.SelectMany(s => l1.Select(s1 => $"{s} {s1},")).ToList().ForEach(Console.WriteLine);

            //Console.ReadKey();


            //var r = new Random();

            //var utterances = Enumerable.Range(1, 999).Select(i =>
            //{
            //    return Convert.ToBoolean(r.Next(2)) ? ToKnowIntent() : ToCompareIntent();
            //}).ToList();

            //File.WriteAllText(@"C:\Users\rigo\Google Drive\JOB\Digevo\Git\LUISJsonTrainerGenerator\LUISJsonTrainer.json", JsonConvert.SerializeObject(utterances));

            //Console.WriteLine(Convert.ToBoolean(r.Next(2)));
            //Console.ReadKey();
        }

        static Utterance ToCompareIntent()
        {
            var r = new Random();
            var l = new List<EntityInfo>();

            var indicadores = entities["indicador"];
            var indicador = indicadores[r.Next(indicadores.Count)];

            var fechasRelativaCorta = entities["fecha_relativa_corta"];
            var fechaRelativaCorta = fechasRelativaCorta[r.Next(fechasRelativaCorta.Count)];

            var adjetivosTiempo = entities["adjetivo_tiempo"];
            var adjetivoTiempo = adjetivosTiempo[r.Next(adjetivosTiempo.Count)];

            var medidasTiempo = entities["medida_tiempo"];
            var medidaTiempo = medidasTiempo[r.Next(medidasTiempo.Count)];

            var diasSemana = entities["dia_semana"];
            var diaSemana = diasSemana[r.Next(diasSemana.Count)];

            var sb = new StringBuilder();

            if (Convert.ToBoolean(r.Next(2)))
            {
                if (Convert.ToBoolean(r.Next(2)))
                {
                    sb.Append("comparar");
                    sb.Append(" ");
                }

                l.Add(new EntityInfo("indicador", sb.Length, sb.Length + indicador.Length - 1));
                sb.Append(indicador);
                sb.Append(" ");

                l.Add(new EntityInfo("tiempo_relativo", sb.Length, sb.Length + "dentro de".Length - 1));
                sb.Append("dentro de");
                sb.Append(" ");

                var c = sb.Length;
                sb.Append(r.Next(10) + 1);
                sb.Append(" ");

                l.Add(new EntityInfo("datetime", c, sb.Length + medidaTiempo.Length - 1));
                sb.Append(medidaTiempo);
            }
            else
            {
                if (Convert.ToBoolean(r.Next(2)))
                {
                    sb.Append("comparar");
                    sb.Append(" ");
                }

                l.Add(new EntityInfo("indicador", sb.Length, sb.Length + indicador.Length - 1));
                sb.Append(indicador);
                sb.Append(" ");

                if (Convert.ToBoolean(r.Next(2)))
                {
                    l.Add(new EntityInfo("tiempo_relativo", sb.Length, sb.Length + "respecto".Length - 1));
                    sb.Append("respecto");
                    sb.Append(" ");
                }
                else
                {
                    l.Add(new EntityInfo("tiempo_relativo", sb.Length, sb.Length + "con respecto".Length - 1));
                    sb.Append("con respecto");
                    sb.Append(" ");
                }

                if (Convert.ToBoolean(r.Next(2)))
                {
                    l.Add(new EntityInfo("datetime", sb.Length, sb.Length + fechaRelativaCorta.Length - 1));
                    sb.Append(fechaRelativaCorta);
                }
                else
                {
                    var c = sb.Length;
                    sb.Append(adjetivoTiempo);
                    sb.Append(" ");

                    if (Convert.ToBoolean(r.Next(2)))
                    {
                        l.Add(new EntityInfo("datetime", c, sb.Length + medidaTiempo.Length - 1));
                        sb.Append(medidaTiempo);
                    }
                    else
                    {
                        l.Add(new EntityInfo("datetime", c, sb.Length + diaSemana.Length - 1));
                        sb.Append(diaSemana);
                    }
                }
            }

            return new Utterance(sb.ToString(), "comparar", l);
        }

        static Utterance ToKnowIntent()
        {
            var r = new Random();
            var l = new List<EntityInfo>();

            var indicadores = entities["indicador"];
            var indicador = indicadores[r.Next(indicadores.Count)];

            var fechasRelativaCorta = entities["fecha_relativa_corta"];
            var fechaRelativaCorta = fechasRelativaCorta[r.Next(fechasRelativaCorta.Count)];

            var adjetivosTiempo = entities["adjetivo_tiempo"];
            var adjetivoTiempo = adjetivosTiempo[r.Next(adjetivosTiempo.Count)];

            var medidasTiempo = entities["medida_tiempo"];
            var medidaTiempo = medidasTiempo[r.Next(medidasTiempo.Count)];

            var diasSemana = entities["dia_semana"];
            var diaSemana = diasSemana[r.Next(diasSemana.Count)];

            var sb = new StringBuilder();
            if (Convert.ToBoolean(r.Next(2)))
            {
                sb.Append("conocer");
                sb.Append(" ");
            }

            l.Add(new EntityInfo("indicador", sb.Length, sb.Length + indicador.Length - 1));
            sb.Append(indicador);
            sb.Append(" ");
            if (Convert.ToBoolean(r.Next(2)))
            {
                l.Add(new EntityInfo("datetime", sb.Length, sb.Length + fechaRelativaCorta.Length - 1));
                sb.Append(fechaRelativaCorta);
            }
            else
            {
                var c = sb.Length;
                sb.Append(adjetivoTiempo);
                sb.Append(" ");
                if (Convert.ToBoolean(r.Next(2)))
                {
                    l.Add(new EntityInfo("datetime", c, sb.Length + medidaTiempo.Length - 1));
                    sb.Append(medidaTiempo);
                }
                else
                {
                    l.Add(new EntityInfo("datetime", c, sb.Length + diaSemana.Length - 1));
                    sb.Append(diaSemana);
                }
            }

            return new Utterance(sb.ToString(), "conocer", l);
        }
    }
}
