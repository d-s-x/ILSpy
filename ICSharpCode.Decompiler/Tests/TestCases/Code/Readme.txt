Each file would be tested agaist all supported compilers in all possible
combinations of optimization and debug options. 
However it is possible to skip or ignore some of combinations.

To achieve this a special directive should be placed into beginning of test suit file.
'// #exclude [options] : <reason>' - to skip test case
'// #ignore [options] : <reason>' - to ignore test case

where 'reason'  - any text

where 'options':
  'option' ['option' ...]

where 'option':
  o-      - code optimization disabled
  o+      - code optimization enabled
  d-      - generation debugging information disabled
  d+      - generation debugging information enabled
  v2      - CLR v2.0 compiler
  v4      - CLR v4.0 compiler
  v4r     - Roslyn compiler

Remarks:
Multiple directives can be specified at the same time.
Exclude directives have higher priority than ignore.
Directives are checked it order they specified.

Examples:
// #exclude v2 : doesn't support modern features
  - do not test against v2.0 compiler.

// #ignore v4r o+ : not implemented yet
  - mark tests against Roslyn compiler with code optimization as ignored.

// #ignore : not implemented yet
  - mark all combinations as ignored.
