import 'package:get_it/get_it.dart';

import '../ui/controllers/controllers.dart';

final getIt = GetIt.instance;

void setupEntities() {
  // Register your entities here
  getIt.registerSingleton<LoginController>(LoginController());
}
