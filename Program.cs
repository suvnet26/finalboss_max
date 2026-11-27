using Ui;
using Services;
using Repositories;
string connectionString = DatabaseCfg.GetConnection();
UserRepository userRepository = new UserRepository(connectionString);
BankAccountRepositories bankAccountRepositories = new(connectionString);
IAuthService authService = new AuthService(userRepository);
IUserInterface start = new StartUi(authService);
start.run();
