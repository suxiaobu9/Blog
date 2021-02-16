## 1.[att=value] 匹配包含給定屬性的元素

```js
$("[name=checkbox3]").click();
```

- [ ] checkbox1
- [ ] checkbox2
- [x] checkbox3
- [ ] checkbox4
- [ ] checkbox1test
- [ ] checkbox2test
- [ ] checkbox3test
- [ ] checkbox4test

## 2.[att*=value] 模糊匹配

```js
$("[name*=x1]").click();
```

- [x] checkbox1
- [ ] checkbox2
- [ ] checkbox3
- [ ] checkbox4
- [x] checkbox1test
- [ ] checkbox2test
- [ ] checkbox3test
- [ ] checkbox4test

## 3.[att!=value] 不能是這個值

```js
$("[name!=checkbox3]").click();
```

- [x] checkbox1
- [x] checkbox2
- [ ] checkbox3
- [x] checkbox4
- [x] checkbox1test
- [x] checkbox2test
- [x] checkbox3test
- [x] checkbox4test

## 4.[att$=value] 結尾是這個值

```js
$("[name$=test]").click();
```

- [ ] checkbox1
- [ ] checkbox2
- [ ] checkbox3
- [ ] checkbox4
- [x] checkbox1test
- [x] checkbox2test
- [x] checkbox3test
- [x] checkbox4test

## 5.[att^=value] 開頭是這個值

```js
$("[name^=checkbox]").click();
```

- [x] checkbox1
- [x] checkbox2
- [x] checkbox3
- [x] checkbox4
- [x] checkbox1test
- [x] checkbox2test
- [x] checkbox3test
- [x] checkbox4test
