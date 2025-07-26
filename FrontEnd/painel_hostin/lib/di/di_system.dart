import 'package:get_it/get_it.dart';
import 'package:painel_hostin/ui/controllers/config.dart';

final getIt = GetIt.instance;

void setupDi() {
  getIt.registerSingleton<Config>(Config());
}
