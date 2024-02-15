using BackendChallengeApi.Core.Model;
using BackendChallengeApi.Exceptions;
using BackendChallengeApi.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendChallengeApi.Core.Services
{
    public class ClientService
    {

        private ClienteDbContext dbContext; 

        public ClientService(ClienteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
            
        public async Task<Cliente> SaveCliente(Cliente client)
        {
            Boolean cnpjExists = await dbContext.Clientes.AnyAsync(c => c.Cnpj == client.Cnpj);

            if (cnpjExists){
                throw new ClienteExistsException("Já existe um cliente com o mesmo CNPJ no banco de dados.");
            }

            try{
                client.DateCadaster = DateTime.UtcNow;
                dbContext.Add(client);
                await dbContext.SaveChangesAsync();
                return client; 

            } catch (Exception ex){
                throw new Exception(ex.StackTrace); 
            }
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await dbContext.Clientes.ToListAsync(); 
        }

        public async Task<bool> RemoveClienteAsync(int id_client)
        {
            var client_delete = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id_client);

            if(client_delete != null)
            {
                dbContext.Clientes.Remove(client_delete);
                await dbContext.SaveChangesAsync();
                return true;  
            }
            return false; 
        }

        public async Task<Cliente> EditarCliente(int id_client, Cliente cliente)
        {
            var client_base = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id_client);

            if (client_base == null)
            {
                throw new NotFoundClienteException("Cliente não encontrado na base de dados. Favor inserir novo cliente!");
            }

            client_base.Name = cliente.Name;
            client_base.Cnpj = cliente.Cnpj;
            client_base.Endereco = cliente.Endereco;
            client_base.Telefone = cliente.Telefone;

            dbContext.Clientes.Update(client_base);
            await dbContext.SaveChangesAsync();

            return client_base;
        }

        public async Task<Cliente> BuscarPorCodigo(int id_client)
        {
            var client_base = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id_client);

            if (client_base == null)
            {
                throw new NotFoundClienteException("Cliente não encontrado na base de dados!");
            }
            return await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id_client);
        }


    }
}
