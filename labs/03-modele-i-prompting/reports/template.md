# Raport — Laboratorium 03

**Zespół:**  AlignRoute - Kamila Wachulec, Ziemowit Jakuczun, Mateusz Rutkowski, Konrad Typa
**Data:**  16.10.2026

## Środowisko

| Parametr | Wartość |
|----------|---------|
| PCS | - |
| Sprzęt (CPU/GPU, RAM) | - |
| Liczba dostępnych notatek | 170 |

## EXP-00 — Sposób oceny wyników

Jak oceniamy poprawność odpowiedzi modelu? Jakie metryki przyjmujemy i dlaczego?

| Metryka | Definicja |
|---------|-----------|
| | |

## EXP-01 — Porównanie modeli

| Model | Floor accuracy | Elevator accuracy | Exact match | Średni czas [ms] |
|-------|----------------|-------------------|-------------|------------------|
| gpt-oss_120b | 100% | 100% | 100% | 784 |
| bielik_11b | 20% | 20% | 20% | 1418 |
| DeepSeek-V3.1 | 90% | 80% | 80% | 363 |
| DeepSeek-V4-Flash | 80% | 70% | 60% | 227 |


**Exact match** oznacza odsetek notatek, dla których model poprawnie rozpoznał jednocześnie oba pola: `floor` i `elevator`.

**Wnioski:** Najlepszym modelem okazał się być bezkonkurencyjnie gpt. Za to DeepSeek-V4-Flash w porównaniu do DeepSeek-V3.1 wypada znacznie gorzej bez zauważalnej różnicy czasowej.

## EXP-02 — Prompting
**Model:** gpt-oss_120b

| Wariant | Floor accuracy | Elevator accuracy | Exact match |
|---------|----------------|-------------------|-------------|
| zero-shot | 100%           | 100%              | 100%        |
| one-shot | 100%           | 80%               | 80%         |
| few-shot | 100%           | 90%               | 90%         |

**Wnioski:**

## EXP-03 — Temperature

| Temperature | Exact match | Powtarzalne notatki |
|-------------|-------------|---------------------|
| 0.0 | 90%         | 8/10                |
| 0.5 | 86%         | 8/10                |
| 1.0 | 88%         | 8/10                |

**Wnioski:**

## EXP-04 — Structured output — JSON i walidacja

| Wariant | Poprawny JSON | Exact match |
|---------|---------------|-------------|
| prompt | 10/10         | 90%         |
| json-schema | 10/10          | 100%        |

**Wnioski:**

## Najtrudniejsze notatki

Które notatki model najczęściej interpretował błędnie i dlaczego?

## Rekomendacja

Który model i prompt wybieramy do projektu — i jakie mamy dowody, że to dobry wybór?
