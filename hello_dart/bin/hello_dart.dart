import 'dart:math';
import 'package:http/http.dart' as http;

void main(List<String> arguments) async {
  var randomCharacterId = getRandomCharacterId();
  await sendRequest(randomCharacterId);
}

Future<void> sendRequest(int characterId) async {
  const url = 'https://swapi.dev/api/people';
  var response = await http.get('$url/$characterId');
  print('Your random Star Wars character today:');
  print(response.body);
}

int getRandomCharacterId() => Random().nextInt(84) + 1;
