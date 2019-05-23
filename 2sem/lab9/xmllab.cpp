#include <libxml++/libxml++.h>
#include <curl/curl.h>
#include <iostream>
#include <string>

using namespace std;

static size_t writeCallback(void *contents, size_t size, size_t nmemb, void *userp)
{
    ((std::string *)userp)->append((char *)contents, size * nmemb);
    return size * nmemb;
}

bool startsWith(const char *pre, const char *str)
{
    size_t lenpre = strlen(pre),
           lenstr = strlen(str);
    return lenstr < lenpre ? 0 : strncmp(pre, str, lenpre) == 0;
}

int main(int arg_c, char **args)
{
    if (arg_c < 3)
    {
        switch (arg_c)
        {
        case 1:
            cout << "All Arguments missed" << endl;
            break;
        case 2:
            cout << "1 Argument missed" << endl;
            break;

        default:
            cout << "All Arguments missed" << endl;
            break;
        }

        return 1;
    }

    char *latArg, *lonArg;
    int countArgs = 0;

    for (int i = 0; i < arg_c; i++)
    {
        char *arg = args[i];
        if (startsWith("--lat=", arg))
        {
            latArg = arg + 6;
            ++countArgs;
        }
        else if (startsWith("--lon=", arg))
        {
            lonArg = arg + 6;
            ++countArgs;
        }
    }

    if (countArgs < 2)
    {
        cout << "Invalid Argument" << endl;
        return 2;
    }

    if (stod(latArg) > 90 || stod(latArg) < 0)
    {
        cout << "the latitude must be from 0 to 90" << endl;
        return 3;
    }

    if (stod(lonArg) > 180 || stod(lonArg) < 0)
    {
        cout << "the longitude must be from 0 to 180" << endl;
        return 4;
    }

    string lat(latArg);
    string lon(lonArg);

    CURL *curl = curl_easy_init();
    std::string readBuffer;

    string xmlSettings("&mode=xml&units=metric");
    string APPID("APPID=b332962152d1ba0bb3f785794f1dc02d");

    string resUrl("https://api.openweathermap.org/data/2.5/weather?");
    resUrl += "lat=" + lat + "&" + "lon=" + lon + "&" + APPID + xmlSettings;

    curl_easy_setopt(curl, CURLOPT_URL, resUrl.c_str());
    curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, writeCallback);
    curl_easy_setopt(curl, CURLOPT_WRITEDATA, &readBuffer);
    curl_easy_perform(curl);
    curl_easy_cleanup(curl);

    xmlpp::DomParser parser;
    parser.parse_memory(readBuffer);
    auto root = parser.get_document()->get_root_node();
    auto children = root->get_children();

    double original_value = 0.0;
    double target_value = 0.0;

    auto temperature_node = reinterpret_cast<xmlpp::Element *>((root)->get_first_child("temperature"));
    auto humidity_node = reinterpret_cast<xmlpp::Element *>((root)->get_first_child("humidity"));
    auto pressure_node = reinterpret_cast<xmlpp::Element *>((root)->get_first_child("pressure"));
    auto weather_node = reinterpret_cast<xmlpp::Element *>((root)->get_first_child("weather"));
    auto city_node = reinterpret_cast<xmlpp::Element *>((root)->get_first_child("city"));

    auto weather_value(weather_node->get_attribute("value"));
    auto pressure_value(pressure_node->get_attribute("value"));
    auto humidity_value(humidity_node->get_attribute("value"));
    auto temperature_value(temperature_node->get_attribute("value"));
    auto city_value(city_node->get_attribute("name"));

    cout << "city: " << city_value->get_value() << "\n"
         << "temperature: " << temperature_value->get_value() << "\n"
         << "humidity: " << humidity_value->get_value() << "%"
         << "\n"
         << "pressure: " << pressure_value->get_value() << " hPa"
         << "\n"
         << "weather: " << weather_value->get_value() << "\n";

    return 0;
}