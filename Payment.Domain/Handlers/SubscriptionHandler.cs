using System;
using Flunt.Notifications;
using Flunt.Validations;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.Repositories;
using Payment.Domain.Services;
using Payment.Domain.ValueObjects;
using Payment.Shared.Commands;
using Payment.Shared.Handlers;

namespace Payment.Domain.Handlers
{
    public class SubscriptionHandler : 
            Notifiable<Notification>, 
            IHandler<CreateBoletoSubscriptionCommand>,
            IHandler<CreatePayPalSubscriptionCommand>,
            IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if(!command.IsValid){
                AddNotifications(command);
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            }
            //Verificar se documento está cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se email está cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso");

            //Gerar VOs
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var address = new Address(command.Street,command.Number,command.Neighborhood, command.City,command.State,command.Country, command.ZipCode);
            var email = new Email(command.Email);

            //Gerar Entidades
            var student = new Student(name,document,email,address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode,command.BoletoNumber,command.PaidDate,command.ExpireDate,command.Total,command.TotalPaid,address, new Document(command.PayerDocument, command.PayerDocumentType),command.Payer,email);
            
            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar Validações
            AddNotifications(name,document,email,address,student,subscription,payment);
            
            //Chegar as notificações
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            
            //Salvar Informações
            _repository.CreateSubscription(student);            
            
            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem Vindo ao Site","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if(!command.IsValid){
                AddNotifications(command);
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            }
            //Verificar se documento está cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se email está cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso");

            //Gerar VOs
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var address = new Address(command.Street,command.Number,command.Neighborhood, command.City,command.State,command.Country, command.ZipCode);
            var email = new Email(command.Email);

            //Gerar Entidades
            var student = new Student(name,document,email,address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate,command.ExpireDate,command.Total,command.TotalPaid,address, new Document(command.PayerDocument, command.PayerDocumentType),command.Payer,email);
            
            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar Validações
            AddNotifications(name,document,email,address,student,subscription,payment);
            
            //Chegar as notificações
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            
            //Salvar Informações
            _repository.CreateSubscription(student);            
            
            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem Vindo ao Site","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if(!command.IsValid){
                AddNotifications(command);
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            }
            //Verificar se documento está cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se email está cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso");

            //Gerar VOs
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var address = new Address(command.Street,command.Number,command.Neighborhood, command.City,command.State,command.Country, command.ZipCode);
            var email = new Email(command.Email);

            //Gerar Entidades
            var student = new Student(name,document,email,address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderName,command.CardNumber,command.LastTransactionNumber, command.PaidDate,command.ExpireDate,command.Total,command.TotalPaid,address, new Document(command.PayerDocument, command.PayerDocumentType),command.Payer,email);
            
            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar Validações
            AddNotifications(name,document,email,address,student,subscription,payment);
            
            //Chegar as notificações
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");
            
            //Salvar Informações
            _repository.CreateSubscription(student);            
            
            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem Vindo ao Site","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}