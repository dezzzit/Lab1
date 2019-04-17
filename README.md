# Lab2 Perfomance results for 1x10^6:
|              Method |    Mean |    Error |   StdDev |  Median | Ratio | Rank |
|-------------------- |--------:|---------:|---------:|--------:|------:|-----:|
| DefaultHashFunction | 11.45 s | 0.2672 s | 0.7753 s | 11.23 s |  1.00 |    1 |
|                     |         |          |          |         |       |      |
|   FirstHashFunction | 15.20 s | 0.8334 s | 2.4179 s | 14.41 s |  1.00 |    1 |
|                     |         |          |          |         |       |      |
|  SecondHashFunction | 14.58 s | 0.3572 s | 0.9839 s | 14.56 s |  1.00 |    1 |
|  ConstHashFunction  | Too much| processing |- | -|  - |  - |

#Lab 3 Results for Unions 
|             Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Rank |
|------------------- |---------:|----------:|----------:|------:|--------:|-----:|
|    UnionCollection | 2.299 ms | 0.1920 ms | 0.5661 ms |  1.00 |    0.00 |    1 |
|                    |          |           |           |       |         |      |
| UnionAllCollection | 406.20 ms| 0.12 ms	  |   402 ms  | 1.00 |   0.00 |    1 |
