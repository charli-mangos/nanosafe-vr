# Security policy

NanoSafe VR is a finished research and training prototype (2022) and is not actively maintained.
Security reports are still welcome.

## Reporting a vulnerability

Please report vulnerabilities **privately** through GitHub's private vulnerability reporting:
open the repository's **Security** tab and choose **Report a vulnerability**.

Please do not open public issues for security problems.

## Known issues

- The project targets Unity 2019.4.31f1, which is affected by
  [CVE-2025-59489](https://unity.com/security/sept-2025-01). Player builds must be rebuilt with
  Unity 2019.4.41f1 or later, or patched with Unity's Application Patcher, before they are distributed.
- The project uses the deprecated built-in XR (Oculus and OpenVR legacy packages).
