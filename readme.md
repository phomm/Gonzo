`I` Задача о длиной цепочке единиц ⭐⭐

Дана последоватльность 0 и 1</br>
Нужно найти самую длинную последовательность из 1 (единиц) после удаления любого элемента
```go
func maxOnesAfterRemoveItem([]byte) uint
```

```go
assert(maxOnesAfterRemoveItem[0,0] == 0)
assert(maxOnesAfterRemoveItem[0,1] == 1)
assert(maxOnesAfterRemoveItem[1,0] == 1)
assert(maxOnesAfterRemoveItem[1,1] == 1)
assert(maxOnesAfterRemoveItem[1, 1, 0, 1, 1] == 4)
assert(maxOnesAfterRemoveItem[1, 1, 0, 1, 1, 0, 1, 1, 1] == 5)
assert(maxOnesAfterRemoveItem[1, 1, 0, 1, 1, 0, 1, 1, 1, 0] == 5)
```

Что хочется увидеть:
- Алгоритм со сложностью **O(N)** по времени и **O(1)** по памяти