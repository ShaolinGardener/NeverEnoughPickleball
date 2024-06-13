import requests

# send code
url = "https://api.telnyx.com/v2/verifications/sms"

payload = {
  "phone_number": "+4074320511",
  "timeout_secs": 300,
  "verify_profile_id": "49000188-bedb-116f-9c98-27c0e00d9853"

  # "phone_number": "+14074320511",
  # "timeout_secs": 300,
  # "verify_profile_id": "49000188-bedb-116f-9c98-27c0e00d9853" #"40017fd6-6c23-4d0b-907f-d4ee11a9f9da"  # 49000188-b621-e039-159a-42d377a000b5
}

headers = {
  "Content-Type": "application/json",
  "Authorization": "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H"
}
# KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H  
# http://telnyxwebhooks.com:8084/947fe81f-e8ba-499b-9128-e34e2fd446ce
response = requests.post(url, json=payload, headers=headers)

data = response.json()
print(data)

# # post code

# phone_number = "+14077668433"
# url = "https://api.telnyx.com/v2/verifications/by_phone_number/" + phone_number + "/actions/verify"

# payload = {
#   "code": "45706",
#   "verify_profile_id": "49000188-b621-e039-159a-42d377a000b5"
# }

# headers = {
#   "Content-Type": "application/json",
#   "Authorization": "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H"
# }

# response = requests.post(url, json=payload, headers=headers)

# data = response.json()
# print(data)


# # list all profiles
# url = "https://api.telnyx.com/v2/verify_profiles"

# query = {
#   "filter[name]": "string",
#   "page[size]": "25",
#   "page[number]": "1"
# }

# headers = {"Authorization": "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H"}

# response = requests.get(url, headers=headers, params=query)

# data = response.json()
# print(data)


# # create a verify profile
# url = "https://api.telnyx.com/v2/verify_profiles"

# payload = {
#   "call": {
#     "default_call_timeout_secs": 30,
#     "default_verification_timeout_secs": 300,
#     "msg_template": "Never Enough Pickleball asks that you use this code to verify your account: {code}."
#   },
#   "flashcall": {
#     "default_verification_timeout_secs": 300
#   },
#   "language": "en-US",
#   "name": "NEP Profile",
#   "psd2": {
#     "default_verification_timeout_secs": 300
#   },
#   "sms": {
#     "default_verification_timeout_secs": 300,
#     "messaging_enabled": True,
#     "messaging_template": "Never Enough Pickleball asks that you use this code to verify your account: {code}.",
#     "rcs_enabled": True,
#     "vsms_enabled": True
#   },
#   "webhook_failover_url": "http://example.com/webhook/failover",
#   "webhook_url": "http://example.com/webhook"
# }

# headers = {
#   "Content-Type": "application/json",
#   "Authorization": "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H"
# }

# response = requests.post(url, json=payload, headers=headers)

# data = response.json()
# print(data)

# # delete a profile
# verify_profile_id = "49000188-b621-e039-159a-42d377a000b5"
# url = "https://api.telnyx.com/v2/verify_profiles/" + verify_profile_id

# headers = {"Authorization": "Bearer KEY017FD66C21CDAFAB529ADA65143E4732_80pR9RDgOr9IbdCVuruY6H"}

# response = requests.delete(url, headers=headers)

# data = response.json()
# print(data)