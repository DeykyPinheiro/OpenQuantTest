using OpenQuantTest.Data;
using OpenQuantTest.Models;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;
using System.Transactions;

namespace OpenQuantTest.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly IUserRepository _userRepository;

        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository,
            IUserRepository userRepository,
            IAccountRepository accountRepository
            )
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public async Task<TransactionModel> Deposit(int id, decimal amount)
        {
            UserModel user = await _userRepository.FindById(id);
            if (user == null)
            {
                throw new Exception($"Usuario de Id: {id} não Encontrado.");
            }
            TransactionModel transaction = new TransactionModel(user, user, amount);
            await _transactionRepository.Save(transaction);
       
            await _accountRepository.Update(user.Id, amount);

            return transaction;
        }
        public async Task<TransactionModel> Transfer(int payerId, int receiverId, decimal amount)
        {
            UserModel payer = await _userRepository.FindById(payerId);
            UserModel receiver = await _userRepository.FindById(receiverId);
            TransactionModel transaction = new TransactionModel(payer, receiver, amount);
            if (!await IsValidTransferAsync(transaction))
            {
                throw new Exception($"Operacao invalida, verifique a quantia e tente novamente");
            }

            await _accountRepository.Update(payer.Id, -amount);
            await _accountRepository.Update(receiver.Id, amount);
            TransactionModel transfer = await _transactionRepository.Save(transaction);
            return transfer;
        }



        private async Task<bool> IsValidTransferAsync(TransactionModel transaction)
        {
            UserModel payer = await _userRepository.FindById(transaction.Payer.Id);

            if (payer == null)
            {
                throw new Exception($"Usuario de Id: {transaction.Payer.Id} não Encontrado.");
            }
            AccountModel payerAccount = await _accountRepository.FindById(payer.Id);

            UserModel receiver = await _userRepository.FindById(transaction.Receiver.Id);
            if (payer == null)
            {
                throw new Exception($"Usuario de Id: {transaction.Receiver.Id} não Encontrado.");
            }

            if (transaction.Receiver.Id == transaction.Payer.Id)
            {
                throw new Exception($"Remetente e Destinatario precisam ser diferentes");
            }

            if (payerAccount.Balance < transaction.Amount)
            {
                return false;
            }

            return true;
        }

    }
}
