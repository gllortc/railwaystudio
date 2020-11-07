using System;
using System.Data.OleDb;
using Rwm.Otc.fremo;

namespace Rwm.collection.Model
{
   /// <summary>
   /// Implementa una clase que permite guardar objetos OTCFremoFreightCar en una tabla de
   /// base de daos.
   /// </summary>
   public class FremoDAO
   {
      private RCApplication _app = null;

      /// <summary>
      /// Constructor de la clase.
      /// </summary>
      /// <param name="app">Instáncia de RCApplication.</param>
      public FremoDAO(RCApplication application)
      {
         _app = application;
      }

      #region Methods

      /// <summary>
      /// Recupera las propiedades de la ficha de un vagón.
      /// </summary>
      /// <param name="carId">Identificador de la ficha.</param>
      /// <returns>Una instáncia de RCFremoCar.</returns>
      public OTCFremoFreightCar Item(int carId)
      {
         OleDbCommand cmd = null;
         OleDbDataReader read = null;
         OTCFremoFreightCar car = null;

         try
         {
            string sql = "SELECT carmodelid,caradminid,carnumber,carepoche,cartype,cartypepre,cartypepost, " +
                                "caruic,cardesc,carmaxspeed,carlong,carlongaxels,carweight,carloadlong,carloadsurf, " +
                                "carloadvol,carloaddesc,caroptions " +
                         "FROM cars " +
                         "WHERE carid=@carid";

            _app.Connect();
            cmd = new OleDbCommand(sql, _app.Connection);

            cmd.Parameters.Add(new OleDbParameter("@carid", OleDbType.Integer));
            cmd.Parameters["@carid"].Value = carId;

            read = cmd.ExecuteReader();
            if (read.Read())
            {
               car = new OTCFremoFreightCar();
               car.Id = carId;
               car.ModelId = (read.IsDBNull(0)) ? 0 : read.GetInt32(0);
               car.AdministrationId = (read.IsDBNull(1)) ? 0 : read.GetInt32(1);
               car.Number = (read.IsDBNull(2)) ? "" : read.GetString(2);
               car.Epoche = (OTCFremoFreightCar.FREMOEpoche)(read.IsDBNull(3) ? (int)OTCFremoFreightCar.FREMOEpoche.Undefined : read.GetInt32(3));
               car.TypeName = (read.IsDBNull(4)) ? "" : read.GetString(4);
               car.TypeNamePre = (read.IsDBNull(5)) ? "" : read.GetString(5);
               car.TypeNamePost = (read.IsDBNull(6)) ? "" : read.GetString(6);
               car.UIC = (read.IsDBNull(7)) ? "" : read.GetString(7);
               car.Description = (read.IsDBNull(8)) ? "" : read.GetString(8);
               car.SpeedMax = (read.IsDBNull(9)) ? 0 : read.GetInt32(9);
               car.Longitude = (read.IsDBNull(10)) ? 0 : read.GetDecimal(10);
               car.LongBetweenAxels = (read.IsDBNull(11)) ? 0 : read.GetDecimal(11);
               car.Weight = (read.IsDBNull(12)) ? 0 : read.GetDecimal(12);
               car.LoadLongitude = (read.IsDBNull(13)) ? 0 : read.GetDecimal(13);
               car.LoadSurface = (read.IsDBNull(14)) ? 0 : read.GetDecimal(14);
               car.LoadVolume = (read.IsDBNull(15)) ? 0 : read.GetDecimal(15);
               car.LoadComments = (read.IsDBNull(16)) ? "" : read.GetString(16);
               car.Options = (read.IsDBNull(17)) ? 0 : read.GetInt32(17);
            }
            read.Close();

            return car;
         }
         catch (Exception e)
         {
            throw e;
         }
         finally
         {
            read.Dispose();
            cmd.Dispose();
         }
      }

      /// <summary>
      /// Actualiza los datos de una ficha de vagón.
      /// </summary>
      /// <param name="model">Una instáncia de RCFremoCar.</param>
      public void Update(OTCFremoFreightCar car)
      {
         OleDbCommand cmd = null;

         try
         {
            string sql = "UPDATE cars SET " +
                         "carmodelid=@carmodelid, " +
                         "caradminid=@caradminid, " +
                         "carnumber=@carnumber, " +
                         "carepoche=@carepoche, " +
                         "cartype=@cartype, " +
                         "cartypepre=@cartypepre, " +
                         "cartypepost=@cartypepost, " +
                         "caruic=@caruic, " +
                         "cardesc=@cardesc, " +
                         "carmaxspeed=@carmaxspeed, " +
                         "carlong=@carlong, " +
                         "carlongaxels=@carlongaxels, " +
                         "carweight=@carweight, " +
                         "carloadlong=@carloadlong, " +
                         "carloadsurf=@carloadsurf, " +
                         "carloadvol=@carloadvol, " +
                         "carloaddesc=@carloaddesc, " +
                         "caroptions=@caroptions " +
                         "WHERE carid=@carid";

            _app.Connect();
            cmd = new OleDbCommand(sql, _app.Connection);

            cmd.Parameters.Add(new OleDbParameter("@carmodelid", OleDbType.Integer));
            cmd.Parameters["@carmodelid"].Value = car.ModelId;

            cmd.Parameters.Add(new OleDbParameter("@caradminid", OleDbType.Integer));
            cmd.Parameters["@caradminid"].Value = car.AdministrationId;

            cmd.Parameters.Add(new OleDbParameter("@carnumber", OleDbType.WChar, 64));
            cmd.Parameters["@carnumber"].Value = car.Number;

            cmd.Parameters.Add(new OleDbParameter("@carepoche", OleDbType.Integer));
            cmd.Parameters["@carepoche"].Value = (int)car.Epoche;

            cmd.Parameters.Add(new OleDbParameter("@cartype", OleDbType.WChar, 25));
            cmd.Parameters["@cartype"].Value = car.TypeName;

            cmd.Parameters.Add(new OleDbParameter("@cartypepre", OleDbType.WChar, 25));
            cmd.Parameters["@cartypepre"].Value = car.TypeNamePre;

            cmd.Parameters.Add(new OleDbParameter("@cartypepost", OleDbType.WChar, 25));
            cmd.Parameters["@cartypepost"].Value = car.TypeNamePost;

            cmd.Parameters.Add(new OleDbParameter("@caruic", OleDbType.WChar, 25));
            cmd.Parameters["@caruic"].Value = car.UIC;

            cmd.Parameters.Add(new OleDbParameter("@cardesc", OleDbType.WChar, 128));
            cmd.Parameters["@cardesc"].Value = car.Description;

            cmd.Parameters.Add(new OleDbParameter("@carmaxspeed", OleDbType.Integer));
            cmd.Parameters["@carmaxspeed"].Value = car.SpeedMax;

            cmd.Parameters.Add(new OleDbParameter("@carlong", OleDbType.Decimal));
            cmd.Parameters["@carlong"].Value = car.Longitude;

            cmd.Parameters.Add(new OleDbParameter("@carlongaxels", OleDbType.Decimal));
            cmd.Parameters["@carlongaxels"].Value = car.LongBetweenAxels;

            cmd.Parameters.Add(new OleDbParameter("@carweight", OleDbType.Decimal));
            cmd.Parameters["@carweight"].Value = car.Weight;

            cmd.Parameters.Add(new OleDbParameter("@carloadlong", OleDbType.Decimal));
            cmd.Parameters["@carloadlong"].Value = car.LoadLongitude;

            cmd.Parameters.Add(new OleDbParameter("@carloadsurf", OleDbType.Decimal));
            cmd.Parameters["@carloadsurf"].Value = car.LoadSurface;

            cmd.Parameters.Add(new OleDbParameter("@carloadvol", OleDbType.Decimal));
            cmd.Parameters["@carloadvol"].Value = car.LoadVolume;

            cmd.Parameters.Add(new OleDbParameter("@carloaddesc", OleDbType.WChar, 255));
            cmd.Parameters["@carloaddesc"].Value = car.LoadComments;

            cmd.Parameters.Add(new OleDbParameter("@caroptions", OleDbType.Integer));
            cmd.Parameters["@caroptions"].Value = car.Options;

            cmd.Parameters.Add(new OleDbParameter("@carid", OleDbType.Integer));
            cmd.Parameters["@carid"].Value = car.Id;

            cmd.ExecuteNonQuery();
         }
         catch
         {
            throw;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      /// <summary>
      /// Agrega una nueva ficha de vagón.
      /// </summary>
      /// <param name="model">Una instáncia de RCFremoCar.</param>
      public void Add(OTCFremoFreightCar car)
      {
         OleDbCommand cmd = null;

         try
         {
            string sql = "INSERT INTO cars (carmodelid,caradminid,carnumber,carepoche,cartype,cartypepre,cartypepost, " +
                                           "caruic,cardesc,carmaxspeed,carlong,carlongaxels,carweight,carloadlong,carloadsurf, " +
                                           "carloadvol,carloaddesc,caroptions) " +
                         "VALUES (@carmodelid,@caradminid,@carnumber,@carepoche,@cartype,@cartypepre,@cartypepost, " +
                                 "@caruic,@cardesc,@carmaxspeed,@carlong,@carlongaxels,@carweight,@carloadlong,@carloadsurf, " +
                                 "@carloadvol,@carloaddesc,@caroptions)";

            _app.Connect();
            cmd = new OleDbCommand(sql, _app.Connection);

            cmd.Parameters.Add(new OleDbParameter("@carmodelid", OleDbType.Integer));
            cmd.Parameters["@carmodelid"].Value = car.ModelId;

            cmd.Parameters.Add(new OleDbParameter("@caradminid", OleDbType.Integer));
            cmd.Parameters["@caradminid"].Value = car.AdministrationId;

            cmd.Parameters.Add(new OleDbParameter("@carnumber", OleDbType.WChar, 64));
            cmd.Parameters["@carnumber"].Value = car.Number;

            cmd.Parameters.Add(new OleDbParameter("@carepoche", OleDbType.Integer));
            cmd.Parameters["@carepoche"].Value = (int)car.Epoche;

            cmd.Parameters.Add(new OleDbParameter("@cartype", OleDbType.WChar, 25));
            cmd.Parameters["@cartype"].Value = car.TypeName;

            cmd.Parameters.Add(new OleDbParameter("@cartypepre", OleDbType.WChar, 25));
            cmd.Parameters["@cartypepre"].Value = car.TypeNamePre;

            cmd.Parameters.Add(new OleDbParameter("@cartypepost", OleDbType.WChar, 25));
            cmd.Parameters["@cartypepost"].Value = car.TypeNamePost;

            cmd.Parameters.Add(new OleDbParameter("@caruic", OleDbType.WChar, 25));
            cmd.Parameters["@caruic"].Value = car.UIC;

            cmd.Parameters.Add(new OleDbParameter("@cardesc", OleDbType.WChar, 128));
            cmd.Parameters["@cardesc"].Value = car.Description;

            cmd.Parameters.Add(new OleDbParameter("@carmaxspeed", OleDbType.Integer));
            cmd.Parameters["@carmaxspeed"].Value = car.SpeedMax;

            cmd.Parameters.Add(new OleDbParameter("@carlong", OleDbType.Decimal));
            cmd.Parameters["@carlong"].Value = car.Longitude;

            cmd.Parameters.Add(new OleDbParameter("@carlongaxels", OleDbType.Decimal));
            cmd.Parameters["@carlongaxels"].Value = car.LongBetweenAxels;

            cmd.Parameters.Add(new OleDbParameter("@carweight", OleDbType.Decimal));
            cmd.Parameters["@carweight"].Value = car.Weight;

            cmd.Parameters.Add(new OleDbParameter("@carloadlong", OleDbType.Decimal));
            cmd.Parameters["@carloadlong"].Value = car.LoadLongitude;

            cmd.Parameters.Add(new OleDbParameter("@carloadsurf", OleDbType.Decimal));
            cmd.Parameters["@carloadsurf"].Value = car.LoadSurface;

            cmd.Parameters.Add(new OleDbParameter("@carloadvol", OleDbType.Decimal));
            cmd.Parameters["@carloadvol"].Value = car.LoadVolume;

            cmd.Parameters.Add(new OleDbParameter("@carloaddesc", OleDbType.WChar, 255));
            cmd.Parameters["@carloaddesc"].Value = car.LoadComments;

            cmd.Parameters.Add(new OleDbParameter("@caroptions", OleDbType.Integer));
            cmd.Parameters["@caroptions"].Value = car.Options;

            cmd.ExecuteNonQuery();
         }
         catch
         {
            throw;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      /// <summary>
      /// Elimina un decodificador si no está asignado a ningún modelo.
      /// </summary>
      /// <param name="carId">Identificador del decodificador.</param>
      public void Delete(int carId)
      {
         OleDbCommand cmd = null;

         try
         {
            // Elimina el registro
            _app.Connect();

            cmd = new OleDbCommand("DELETE FROM cars WHERE carid=@carid", _app.Connection);

            cmd.Parameters.Add(new OleDbParameter("@carid", OleDbType.Integer));
            cmd.Parameters["@carid"].Value = carId;

            cmd.ExecuteNonQuery();
         }
         catch
         {
            throw;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      /// <summary>
      /// Obtiene el identificador de una ficha a partir del identificador del modelo.
      /// </summary>
      /// <param name="modelId">Identificador del modelo.</param>
      /// <returns>Identificador de la ficha.</returns>
      public int GetID(int modelId)
      {
         OleDbCommand cmd = null;

         try
         {
            // Elimina el registro
            _app.Connect();

            cmd = new OleDbCommand("SELECT carid FROM cars WHERE carmodelid=@carmodelid", _app.Connection);

            cmd.Parameters.Add(new OleDbParameter("@carmodelid", OleDbType.Integer));
            cmd.Parameters["@carmodelid"].Value = modelId;

            return (int)cmd.ExecuteScalar();
         }
         catch
         {
            return 0;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      #endregion

   }
}
