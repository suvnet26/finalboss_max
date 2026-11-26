using Ui;
using Services;
using Repositories;
UserRepository userRepository = new UserRepository();
IAuthService authService = new AuthService(userRepository);
IUserInterface start = new StartUi(authService);
start.run();
