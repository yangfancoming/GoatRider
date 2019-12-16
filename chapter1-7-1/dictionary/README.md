

#  Dictionary的描述
       1、从一组键（Key）到一组值（Value）的映射，每一个添加项都是由一个值及其相关连的键组成
       2、任何键都必须是唯一的
       3、键不能为空引用null（VB中的Nothing），若值为引用类型，则可以为空值
       4、Key和Value可以是任何类型（string，int，custom class 等）
   
    Dictionary常用用法：以 key 的类型为 int , value的类型为string 为例

# 其它常见属性和方法的说明：
   
       Comparer：	获取用于确定字典中的键是否相等的 IEqualityComparer。
       Count：	获取包含在 Dictionary中的键/值对的数目。
       Item：	获取或设置与指定的键相关联的值。
       Keys：	获取包含 Dictionary中的键的集合。
       Values：	获取包含 Dictionary中的值的集合。
       Add：	将指定的键和值添加到字典中。
       Clear：	从 Dictionary中移除所有的键和值。
       ContainsKey：	确定 Dictionary是否包含指定的键。
       ContainsValue：	确定 Dictionary是否包含特定值。
       GetEnumerator：	返回循环访问 Dictionary的枚举数。
       GetType：	获取当前实例的 Type。 （从 Object 继承。）
       Remove：	从 Dictionary中移除所指定的键的值。
       ToString：	返回表示当前 Object的 String。 （从 Object 继承。）
       TryGetValue：	获取与指定的键相关联的值。