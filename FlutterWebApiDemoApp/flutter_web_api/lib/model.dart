class User {
  final int UserId;
  final String Name;
  final String Address;

  const User({required this.UserId, required this.Name, required this.Address});

  factory User.fromJson(Map<String, dynamic> json) => User(
      UserId: json['UserId'], Name: json['Name'], Address: json['Address']);

  Map<String, dynamic> toJson() =>
      {"UserId": UserId, "Name": Name, "Address": Address};
}
