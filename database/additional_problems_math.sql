-- Additional Math Problems (20 per grade band)
-- Grade Band 1: Elementary (Grades 1-2, Difficulty 1-2)

-- Counting & Basic Addition (Grade 1)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'counting-advanced', 1, 15, 'Count by 2s: 2, 4, 6, 8, ___', 'MultipleChoice', '8|10|12|14', '10'),
('Math', 'counting-advanced', 1, 15, 'Count backwards: 10, 9, 8, 7, ___', 'MultipleChoice', '5|6|7|8', '6'),
('Math', 'addition-to-10', 1, 15, '4 + 4 = ?', 'FreeResponse', '', '8'),
('Math', 'addition-to-10', 1, 15, '1 + 9 = ?', 'FreeResponse', '', '10'),
('Math', 'addition-to-10', 1, 20, 'Sam has 5 pencils. Mia gives him 3 more. How many does Sam have now?', 'FreeResponse', '', '8|eight'),
('Math', 'subtraction-basic', 1, 15, '7 - 3 = ?', 'FreeResponse', '', '4'),
('Math', 'subtraction-basic', 1, 15, '10 - 4 = ?', 'FreeResponse', '', '6'),
('Math', 'subtraction-basic', 1, 20, 'There are 9 cats. 4 run away. How many are left?', 'FreeResponse', '', '5|five'),
('Math', 'comparing-numbers', 1, 10, 'Which is less: 3 or 8?', 'MultipleChoice', '3|8|Same|Neither', '3'),
('Math', 'comparing-numbers', 1, 10, 'Put in order from smallest to largest: 5, 2, 9', 'MultipleChoice', '2,5,9|5,2,9|9,5,2|2,9,5', '2,5,9'),

-- Place Value & Addition/Subtraction to 20 (Grade 2)
('Math', 'place-value-tens', 2, 20, 'How many tens are in 40?', 'FreeResponse', '', '4|four'),
('Math', 'place-value-tens', 2, 20, 'What number is 3 tens and 7 ones?', 'FreeResponse', '', '37'),
('Math', 'addition-to-20', 2, 25, '12 + 7 = ?', 'FreeResponse', '', '19'),
('Math', 'addition-to-20', 2, 25, '15 + 5 = ?', 'FreeResponse', '', '20'),
('Math', 'addition-to-20', 2, 30, 'Jake has 13 marbles. He finds 6 more. How many does he have total?', 'FreeResponse', '', '19'),
('Math', 'subtraction-to-20', 2, 25, '18 - 9 = ?', 'FreeResponse', '', '9'),
('Math', 'subtraction-to-20', 2, 25, '14 - 5 = ?', 'FreeResponse', '', '9'),
('Math', 'subtraction-to-20', 2, 30, 'Emma had 17 stickers. She gave 8 to her friend. How many does she have left?', 'FreeResponse', '', '9'),
('Math', 'skip-counting', 2, 20, 'Count by 5s: 5, 10, 15, ___', 'MultipleChoice', '16|18|20|25', '20'),
('Math', 'skip-counting', 2, 20, 'Count by 10s: 10, 20, 30, ___', 'MultipleChoice', '31|35|40|50', '40');

-- Grade Band 2: Upper Elementary (Grades 3-5, Difficulty 3-4)

-- Multiplication & Division Basics (Grade 3)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'multiplication-basic', 3, 30, '6 × 7 = ?', 'FreeResponse', '', '42'),
('Math', 'multiplication-basic', 3, 30, '9 × 4 = ?', 'FreeResponse', '', '36'),
('Math', 'multiplication-basic', 3, 35, 'There are 8 boxes with 5 crayons each. How many crayons total?', 'FreeResponse', '', '40'),
('Math', 'division-basic', 3, 35, '24 ÷ 6 = ?', 'FreeResponse', '', '4'),
('Math', 'division-basic', 3, 35, '35 ÷ 5 = ?', 'FreeResponse', '', '7'),
('Math', 'division-basic', 3, 40, '18 cookies divided equally among 3 friends. How many does each get?', 'FreeResponse', '', '6|six'),
('Math', 'fractions-intro', 3, 30, 'What fraction of a pizza is 1 out of 4 slices?', 'MultipleChoice', '1/2|1/3|1/4|1/8', '1/4'),
('Math', 'fractions-intro', 3, 30, 'If you eat 3 out of 8 pieces, what fraction did you eat?', 'MultipleChoice', '3/5|3/8|5/8|1/3', '3/8'),
('Math', 'rounding-tens', 3, 25, 'Round 47 to the nearest ten.', 'FreeResponse', '', '50'),
('Math', 'rounding-tens', 3, 25, 'Round 23 to the nearest ten.', 'FreeResponse', '', '20'),

-- Multi-Digit Operations & Decimals (Grade 4)
('Math', 'multiplication-two-digit', 4, 60, '23 × 6 = ?', 'FreeResponse', '', '138'),
('Math', 'multiplication-two-digit', 4, 60, '18 × 9 = ?', 'FreeResponse', '', '162'),
('Math', 'division-remainders', 4, 60, '29 ÷ 4 = ? remainder ?', 'MultipleChoice', '7 R1|6 R5|7 R2|8 R1', '7 R1'),
('Math', 'division-remainders', 4, 60, '38 ÷ 5 = ? remainder ?', 'MultipleChoice', '7 R3|8 R2|6 R8|7 R4', '7 R3'),
('Math', 'decimals-basic', 4, 40, '0.5 + 0.3 = ?', 'FreeResponse', '', '0.8'),
('Math', 'decimals-basic', 4, 40, '0.9 - 0.4 = ?', 'FreeResponse', '', '0.5'),
('Math', 'fractions-addition', 4, 50, '1/4 + 2/4 = ?', 'MultipleChoice', '1/4|2/4|3/4|4/4', '3/4'),
('Math', 'fractions-addition', 4, 50, '2/5 + 1/5 = ?', 'MultipleChoice', '2/5|3/5|3/10|1/5', '3/5'),
('Math', 'area-perimeter', 4, 45, 'A rectangle is 6 cm long and 4 cm wide. What is its area?', 'FreeResponse', '', '24'),
('Math', 'area-perimeter', 4, 45, 'A square has sides of 5 inches. What is its perimeter?', 'FreeResponse', '', '20');

-- Grade Band 3: Middle School (Grades 6-8, Difficulty 5-7)

-- Fractions, Decimals, Percents (Grade 6)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'fractions-multiplication', 5, 60, '2/3 × 3/4 = ?', 'MultipleChoice', '1/2|5/7|6/12|2/4', '1/2'),
('Math', 'fractions-division', 5, 70, '1/2 ÷ 1/4 = ?', 'FreeResponse', '', '2'),
('Math', 'percent-conversion', 5, 45, 'Convert 0.75 to a percent.', 'FreeResponse', '', '75|75%'),
('Math', 'percent-conversion', 5, 45, 'Convert 3/5 to a percent.', 'FreeResponse', '', '60|60%'),
('Math', 'percent-of-number', 5, 55, 'What is 20% of 80?', 'FreeResponse', '', '16'),
('Math', 'percent-of-number', 5, 55, 'What is 15% of 60?', 'FreeResponse', '', '9'),
('Math', 'ratios-basic', 5, 50, 'Simplify the ratio 12:18', 'MultipleChoice', '2:3|3:2|6:9|4:6', '2:3'),
('Math', 'ratios-basic', 5, 50, 'If 3 apples cost $6, how much do 5 apples cost?', 'FreeResponse', '', '10|$10'),
('Math', 'integers-addition', 5, 40, '-5 + 8 = ?', 'FreeResponse', '', '3'),
('Math', 'integers-subtraction', 5, 40, '4 - (-3) = ?', 'FreeResponse', '', '7'),

-- Pre-Algebra (Grade 7)
('Math', 'algebra-expressions', 6, 60, 'Simplify: 3x + 5x', 'FreeResponse', '', '8x'),
('Math', 'algebra-expressions', 6, 60, 'Simplify: 7y - 2y', 'FreeResponse', '', '5y'),
('Math', 'solving-equations', 6, 75, 'Solve for x: x + 7 = 15', 'FreeResponse', '', '8'),
('Math', 'solving-equations', 6, 75, 'Solve for n: 3n = 24', 'FreeResponse', '', '8'),
('Math', 'order-of-operations', 6, 50, '3 + 4 × 2 = ?', 'FreeResponse', '', '11'),
('Math', 'order-of-operations', 6, 50, '(8 - 3) × 2 = ?', 'FreeResponse', '', '10'),
('Math', 'exponents-basic', 6, 45, '2³ = ?', 'FreeResponse', '', '8'),
('Math', 'exponents-basic', 6, 45, '5² = ?', 'FreeResponse', '', '25'),
('Math', 'slope-intro', 6, 70, 'What is the slope of a line through (0,0) and (2,4)?', 'FreeResponse', '', '2'),
('Math', 'slope-intro', 6, 70, 'What is the slope of a line through (1,3) and (3,7)?', 'FreeResponse', '', '2');

-- Algebra I (Grade 8)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'linear-equations', 7, 90, 'Solve for x: 2x - 5 = 11', 'FreeResponse', '', '8'),
('Math', 'linear-equations', 7, 90, 'Solve for y: 4y + 3 = 19', 'FreeResponse', '', '4'),
('Math', 'systems-equations', 7, 120, 'Solve: x + y = 10 and x - y = 2. What is x?', 'FreeResponse', '', '6'),
('Math', 'factoring-basic', 7, 80, 'Factor: x² + 5x + 6', 'MultipleChoice', '(x+2)(x+3)|(x+1)(x+6)|(x+4)(x+2)|(x+5)(x+1)', '(x+2)(x+3)'),
('Math', 'quadratic-formula', 7, 100, 'For x² - 5x + 6 = 0, what are the solutions?', 'MultipleChoice', 'x=2,x=3|x=1,x=6|x=-2,x=-3|x=5,x=1', 'x=2,x=3'),
('Math', 'inequalities', 7, 75, 'Solve: 2x + 3 > 11', 'MultipleChoice', 'x>4|x>7|x<4|x>14', 'x>4'),
('Math', 'pythagorean-theorem', 7, 90, 'A right triangle has legs 3 and 4. What is the hypotenuse?', 'FreeResponse', '', '5'),
('Math', 'exponential-growth', 7, 85, 'If $100 doubles every year, how much after 3 years?', 'FreeResponse', '', '800|$800'),
('Math', 'polynomials-basic', 7, 70, 'Expand: (x + 3)(x + 2)', 'FreeResponse', '', 'x²+5x+6|x^2+5x+6'),
('Math', 'function-notation', 7, 60, 'If f(x) = 2x + 1, what is f(4)?', 'FreeResponse', '', '9');

-- Grade Band 4: High School (Grades 9-12, Difficulty 8-10)

-- Geometry & Algebra II (Grades 9-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'circle-area', 8, 90, 'What is the area of a circle with radius 5? (Use π ≈ 3.14)', 'FreeResponse', '', '78.5'),
('Math', 'volume-cylinder', 8, 100, 'Volume of cylinder: radius 3, height 10. (Use π ≈ 3.14)', 'FreeResponse', '', '282.6'),
('Math', 'trigonometry-basic', 8, 95, 'In a right triangle, if opposite=3 and hypotenuse=5, what is sin(θ)?', 'FreeResponse', '', '0.6|3/5'),
('Math', 'logarithms-basic', 8, 85, 'Solve: log₂(8) = ?', 'FreeResponse', '', '3'),
('Math', 'complex-numbers', 8, 90, 'Simplify: (2 + 3i) + (1 - i)', 'FreeResponse', '', '3+2i'),
('Math', 'rational-expressions', 8, 100, 'Simplify: (x² - 4)/(x - 2)', 'FreeResponse', '', 'x+2'),
('Math', 'sequences-arithmetic', 8, 75, 'What is the 10th term: 3, 7, 11, 15, ...?', 'FreeResponse', '', '39'),
('Math', 'sequences-geometric', 8, 75, 'What is the 5th term: 2, 6, 18, 54, ...?', 'FreeResponse', '', '162'),
('Math', 'probability-basic', 8, 70, 'Rolling two dice, what is P(sum=7)?', 'MultipleChoice', '1/6|1/12|1/36|5/36', '1/6'),
('Math', 'statistics-mean', 8, 65, 'Mean of: 10, 15, 20, 25, 30?', 'FreeResponse', '', '20');

-- Pre-Calculus (Grades 11-12)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'matrices-basic', 9, 100, 'Add matrices: [1,2;3,4] + [2,0;1,3]. What is top-left element?', 'FreeResponse', '', '3'),
('Math', 'vectors-basic', 9, 95, 'Magnitude of vector <3, 4>?', 'FreeResponse', '', '5'),
('Math', 'conic-sections', 9, 120, 'Equation x² + y² = 25 represents which shape?', 'MultipleChoice', 'Circle|Ellipse|Parabola|Hyperbola', 'Circle'),
('Math', 'parametric-equations', 9, 110, 'If x=2t, y=t², what is y when x=6?', 'FreeResponse', '', '9'),
('Math', 'polar-coordinates', 9, 105, 'Convert (3, 90°) from polar to Cartesian. What is x?', 'FreeResponse', '', '0'),
('Math', 'limits-intro', 9, 90, 'lim(x→2) (x² - 4)/(x - 2) = ?', 'FreeResponse', '', '4'),
('Math', 'trig-identities', 9, 100, 'Simplify: sin²(x) + cos²(x)', 'FreeResponse', '', '1'),
('Math', 'inverse-functions', 9, 85, 'If f(x) = 2x + 3, what is f⁻¹(11)?', 'FreeResponse', '', '4'),
('Math', 'series-sum', 9, 110, 'Sum of geometric series: 1 + 1/2 + 1/4 + ... (infinite)?', 'FreeResponse', '', '2'),
('Math', 'combinatorics', 9, 95, 'How many ways to choose 2 items from 5?', 'FreeResponse', '', '10');

-- Calculus (Grade 12 / College)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'derivatives-basic', 10, 100, 'd/dx (x³) = ?', 'FreeResponse', '', '3x²|3x^2'),
('Math', 'derivatives-basic', 10, 100, 'd/dx (5x² + 3x) = ?', 'FreeResponse', '', '10x+3'),
('Math', 'chain-rule', 10, 120, 'd/dx (x² + 1)³ = ?', 'FreeResponse', '', '6x(x²+1)²|6x(x^2+1)^2'),
('Math', 'integrals-basic', 10, 120, '∫ 2x dx = ?', 'FreeResponse', '', 'x²+C|x^2+C'),
('Math', 'integrals-definite', 10, 130, '∫[0 to 2] x dx = ?', 'FreeResponse', '', '2'),
('Math', 'related-rates', 10, 150, 'If radius grows at 2 cm/s, how fast does area grow when r=5? (dA/dt)', 'FreeResponse', '', '20π|62.8'),
('Math', 'optimization', 10, 140, 'Max area of rectangle with perimeter 20?', 'FreeResponse', '', '25'),
('Math', 'integration-parts', 10, 160, '∫ x·eˣ dx = ?', 'MultipleChoice', 'xeˣ-eˣ+C|xeˣ+C|eˣ+C|x²eˣ+C', 'xeˣ-eˣ+C'),
('Math', 'taylor-series', 10, 150, 'First 3 terms of eˣ Taylor series?', 'MultipleChoice', '1+x+x²/2|1+x+x²|x+x²+x³|1+2x+3x²', '1+x+x²/2'),
('Math', 'differential-equations', 10, 170, 'Solve: dy/dx = 2y, y(0)=1', 'FreeResponse', '', 'e^(2x)|e²ˣ');

-- Additional Cross-Domain Problems (20 new questions)
-- Mixed subjects to provide variety

-- Science - Elementary (Difficulty 2-3)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Science', 'states-of-matter', 2, 30, 'What state of matter is water vapor?', 'MultipleChoice', 'Solid|Liquid|Gas|Plasma', 'Gas'),
('Science', 'plant-parts', 2, 25, 'Which part of a plant absorbs water from soil?', 'MultipleChoice', 'Leaves|Stem|Roots|Flower', 'Roots'),
('Science', 'solar-system', 3, 35, 'Which planet is closest to the Sun?', 'MultipleChoice', 'Venus|Mars|Mercury|Earth', 'Mercury'),
('Science', 'magnets', 3, 30, 'Opposite poles of magnets do what?', 'MultipleChoice', 'Attract|Repel|Nothing|Explode', 'Attract');

-- Science - Middle School (Difficulty 5-6)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Science', 'photosynthesis', 5, 60, 'In photosynthesis, what gas do plants absorb?', 'FreeResponse', '', 'CO2|carbon dioxide'),
('Science', 'density', 5, 70, 'If mass is 50g and volume is 10cm³, what is density?', 'FreeResponse', '', '5|5 g/cm³'),
('Science', 'cell-biology', 6, 65, 'Which organelle is called the powerhouse of the cell?', 'FreeResponse', '', 'mitochondria|mitochondrion'),
('Science', 'periodic-table', 6, 55, 'What is the chemical symbol for gold?', 'FreeResponse', '', 'Au');

-- Reading Comprehension (Difficulty 3-5)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Reading', 'context-clues', 3, 45, 'The dessert was "delectable." Based on context, delectable likely means:', 'MultipleChoice', 'Terrible|Delicious|Cold|Expensive', 'Delicious'),
('Reading', 'main-idea', 4, 60, 'A passage discusses recycling benefits. The main idea is likely about:', 'MultipleChoice', 'Pollution sources|Environmental protection|Factory production|Ocean exploration', 'Environmental protection'),
('Reading', 'inference', 5, 70, 'Sarah grabbed her umbrella and raincoat. We can infer:', 'MultipleChoice', 'It is sunny|It is raining or might rain|She is going swimming|She lost her keys', 'It is raining or might rain');

-- Logic/Critical Thinking (Difficulty 4-7)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Logic', 'pattern-recognition', 4, 50, 'Continue the pattern: 2, 5, 11, 23, ___', 'MultipleChoice', '35|41|47|53', '47'),
('Logic', 'deductive-reasoning', 5, 80, 'All cats are mammals. Felix is a cat. Therefore:', 'MultipleChoice', 'Felix is a dog|Felix is a mammal|Felix is a bird|Felix is not real', 'Felix is a mammal'),
('Logic', 'analogies', 6, 70, 'Teacher is to classroom as doctor is to:', 'MultipleChoice', 'Medicine|Hospital|Patient|Stethoscope', 'Hospital'),
('Logic', 'logical-fallacies', 7, 90, 'Everyone I know likes pizza, so everyone in the world must like pizza. This is an example of:', 'MultipleChoice', 'Hasty generalization|Ad hominem|Straw man|Circular reasoning', 'Hasty generalization');

-- History (Difficulty 4-6)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('History', 'american-history', 4, 50, 'In what year did the United States declare independence?', 'FreeResponse', '', '1776'),
('History', 'world-history', 5, 60, 'Who was the first emperor of Rome?', 'MultipleChoice', 'Julius Caesar|Augustus|Nero|Constantine', 'Augustus'),
('History', 'geography-history', 6, 70, 'Which ancient civilization built Machu Picchu?', 'FreeResponse', '', 'Inca|Incan');

-- Writing/Grammar (Difficulty 3-5)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Writing', 'punctuation', 3, 40, 'Which sentence is correctly punctuated?', 'MultipleChoice', 'I went to the store and bought milk eggs and bread.|I went to the store, and bought milk, eggs, and bread.|I went to the store and bought milk, eggs, and bread.|I went to the store and bought, milk eggs and bread.', 'I went to the store and bought milk, eggs, and bread.'),
('Writing', 'subject-verb-agreement', 4, 50, 'Which sentence is grammatically correct?', 'MultipleChoice', 'The group of students are leaving.|The group of students is leaving.|The group of students were leaving.|The group of students be leaving.', 'The group of students is leaving.');

-- Additional Questions Across All Categories (40+ new questions)

-- MORE MATH - Various Topics (Difficulty 2-8)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'time-basic', 2, 30, 'If it is 3:00 now, what time will it be in 2 hours?', 'FreeResponse', '', '5:00|5'),
('Math', 'money-basic', 2, 25, 'If you have 3 quarters, how many cents do you have?', 'FreeResponse', '', '75'),
('Math', 'measurement', 3, 35, 'How many inches are in 1 foot?', 'FreeResponse', '', '12'),
('Math', 'probability-coins', 5, 45, 'What is the probability of flipping heads on a fair coin?', 'MultipleChoice', '1/4|1/3|1/2|2/3', '1/2'),
('Math', 'negative-numbers', 4, 40, '-8 + 5 = ?', 'FreeResponse', '', '-3'),
('Math', 'absolute-value', 6, 50, 'What is |-15|?', 'FreeResponse', '', '15'),
('Math', 'scientific-notation', 7, 60, 'Express 3,500 in scientific notation.', 'MultipleChoice', '3.5×10²|35×10²|3.5×10³|0.35×10⁴', '3.5×10³'),
('Math', 'distance-formula', 8, 80, 'Distance between (0,0) and (3,4)?', 'FreeResponse', '', '5');

-- MORE SCIENCE - Various Topics (Difficulty 2-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Science', 'animals', 2, 25, 'Which animal is a mammal?', 'MultipleChoice', 'Fish|Snake|Dog|Spider', 'Dog'),
('Science', 'weather', 3, 30, 'What causes thunder?', 'MultipleChoice', 'Clouds bumping|Lightning heating air|Rain falling|Wind blowing', 'Lightning heating air'),
('Science', 'food-chains', 4, 45, 'In a food chain, what are organisms that make their own food called?', 'FreeResponse', '', 'producers'),
('Science', 'force-motion', 5, 55, 'According to Newton, force equals mass times what?', 'FreeResponse', '', 'acceleration'),
('Science', 'chemical-reactions', 6, 70, 'In the equation H₂ + O₂ → H₂O, what needs to be balanced?', 'MultipleChoice', 'Nothing, it is balanced|Add coefficient 2 before H₂O|Add coefficient 2 before H₂|Multiple coefficients needed', 'Multiple coefficients needed'),
('Science', 'ecosystems', 4, 50, 'What is a biome?', 'MultipleChoice', 'A single organism|A large ecosystem with similar climate|A type of cell|A chemical compound', 'A large ecosystem with similar climate'),
('Science', 'genetics', 7, 85, 'If both parents are heterozygous (Aa) for a trait, what percentage of offspring will be homozygous recessive (aa)?', 'MultipleChoice', '0%|25%|50%|75%', '25%'),
('Science', 'physics-energy', 8, 90, 'What type of energy does a compressed spring have?', 'MultipleChoice', 'Kinetic|Potential|Thermal|Nuclear', 'Potential'),
('Science', 'chemistry-bonding', 9, 100, 'What type of bond involves sharing electrons?', 'FreeResponse', '', 'covalent');

-- MORE READING - Various Topics (Difficulty 2-8)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Reading', 'vocabulary-basic', 2, 20, 'Which word means the opposite of "hot"?', 'MultipleChoice', 'Warm|Cold|Wet|Big', 'Cold'),
('Reading', 'parts-of-speech', 3, 35, 'In "The quick brown fox jumps," what part of speech is "quick"?', 'MultipleChoice', 'Noun|Verb|Adjective|Adverb', 'Adjective'),
('Reading', 'synonyms', 4, 40, 'Which word is closest in meaning to "happy"?', 'MultipleChoice', 'Sad|Joyful|Angry|Tired', 'Joyful'),
('Reading', 'figurative-language', 5, 55, '"Her smile was a ray of sunshine" is an example of:', 'MultipleChoice', 'Simile|Metaphor|Hyperbole|Alliteration', 'Metaphor'),
('Reading', 'author-purpose', 6, 65, 'An advertisement for a new phone primarily aims to:', 'MultipleChoice', 'Inform|Persuade|Entertain|Describe', 'Persuade'),
('Reading', 'literary-devices', 7, 75, '"Peter Piper picked a peck" uses which literary device?', 'MultipleChoice', 'Metaphor|Simile|Alliteration|Personification', 'Alliteration'),
('Reading', 'theme-analysis', 8, 90, 'A story where hard work leads to success likely has what theme?', 'MultipleChoice', 'Perseverance pays off|Love conquers all|Honesty is important|Friendship matters', 'Perseverance pays off');

-- MORE LOGIC - Various Topics (Difficulty 2-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Logic', 'basic-sequences', 2, 25, 'What comes next: A, B, C, ___?', 'MultipleChoice', 'A|B|C|D', 'D'),
('Logic', 'simple-patterns', 3, 30, 'Continue: circle, square, circle, square, ___', 'MultipleChoice', 'Triangle|Circle|Square|Rectangle', 'Circle'),
('Logic', 'sets-basic', 5, 55, 'Which number is in both {2,4,6,8} and {3,6,9}?', 'FreeResponse', '', '6'),
('Logic', 'conditional-statements', 6, 70, 'If it rains, the ground is wet. The ground is wet. Therefore:', 'MultipleChoice', 'It rained|It might have rained|It did not rain|It will rain', 'It might have rained'),
('Logic', 'truth-tables', 8, 90, 'In logic, what is the output of (True AND False)?', 'MultipleChoice', 'True|False|Maybe|Undefined', 'False'),
('Logic', 'proof-techniques', 9, 110, 'Proof by contradiction starts by assuming what?', 'MultipleChoice', 'The statement is true|The statement is false|Nothing|Everything', 'The statement is false');

-- HEALTH (Difficulty 1-7)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Health', 'hygiene-basic', 1, 20, 'How often should you brush your teeth?', 'MultipleChoice', 'Once a week|Once a day|Twice a day|Once a month', 'Twice a day'),
('Health', 'nutrition-basics', 2, 30, 'Which food group includes apples and bananas?', 'MultipleChoice', 'Grains|Fruits|Vegetables|Protein', 'Fruits'),
('Health', 'exercise-basics', 3, 35, 'How many minutes of exercise per day is recommended for kids?', 'MultipleChoice', '10 minutes|30 minutes|60 minutes|120 minutes', '60 minutes'),
('Health', 'safety-basic', 2, 25, 'What should you do before crossing the street?', 'MultipleChoice', 'Run quickly|Look both ways|Close your eyes|Walk backwards', 'Look both ways'),
('Health', 'mental-health', 5, 60, 'Which is a healthy way to cope with stress?', 'MultipleChoice', 'Ignore it|Talk to someone you trust|Stay angry|Skip meals', 'Talk to someone you trust'),
('Health', 'first-aid', 6, 70, 'What is the first step for a minor cut?', 'MultipleChoice', 'Apply bandage immediately|Wash with soap and water|Ignore it|Use super glue', 'Wash with soap and water'),
('Health', 'body-systems', 7, 80, 'Which organ pumps blood throughout the body?', 'FreeResponse', '', 'heart');

-- MINECRAFT (Difficulty 1-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Minecraft', 'crafting-basics', 1, 20, 'What tool do you need to mine stone?', 'MultipleChoice', 'Wooden pickaxe or better|Sword|Axe|Shovel', 'Wooden pickaxe or better'),
('Minecraft', 'resources', 2, 30, 'Which material is needed to make a crafting table?', 'MultipleChoice', 'Stone|Wood planks|Iron|Diamond', 'Wood planks'),
('Minecraft', 'mobs', 3, 35, 'What do Creepers do when they get close to you?', 'MultipleChoice', 'Run away|Explode|Shoot arrows|Nothing', 'Explode'),
('Minecraft', 'redstone-basics', 5, 60, 'What does a redstone torch provide?', 'MultipleChoice', 'Light only|Power only|Light and power|Nothing', 'Light and power'),
('Minecraft', 'enchanting', 6, 70, 'What material is needed to build an enchanting table?', 'MultipleChoice', 'Gold blocks|Obsidian and diamonds|Iron blocks|Wood', 'Obsidian and diamonds'),
('Minecraft', 'blast-resistance', 7, 85, 'What block has the highest blast resistance in survival mode that is not bedrock?', 'MultipleChoice', 'Obsidian|Crying obsidian|Ancient debris|Respawn anchor', 'Respawn anchor'),
('Minecraft', 'mob-mechanics', 6, 75, 'What is the only mob that can spawn with random enchantments on its weapon naturally?', 'FreeResponse', '', 'zombie|zombies'),
('Minecraft', 'compass-mechanics', 8, 95, 'Why do compasses spin wildly in the Nether and the End?', 'MultipleChoice', 'No magnetic north exists|No spawn point can be located|Game bug|Too much heat', 'No spawn point can be located'),
('Minecraft', 'spawn-direction', 7, 80, 'What determines the exact direction a player faces when they respawn after death?', 'MultipleChoice', 'Random|Bed orientation when placed|Direction they died facing|Always north', 'Bed orientation when placed'),
('Minecraft', 'village-reputation', 8, 90, 'Why do iron golems sometimes attack players even when they''ve never hit one?', 'MultipleChoice', 'Random aggression|Low village reputation from trading|Bug in code|Moon phase', 'Low village reputation from trading'),
('Minecraft', 'structure-rarity', 9, 110, 'What is the rarest naturally generated structure per chunk, not per world?', 'MultipleChoice', 'Woodland mansion|Ancient city|Fossil|Stronghold', 'Fossil'),
('Minecraft', 'zombie-persistence', 8, 100, 'Why do zombies sometimes pick up items and never despawn?', 'MultipleChoice', 'They become persistent when holding items|Bug|Player proximity|Difficulty setting', 'They become persistent when holding items'),
('Minecraft', 'potion-effects', 9, 105, 'What is the maximum number of different potion effects a single entity can have at once without commands?', 'MultipleChoice', '5|8|13|27', '27'),
('Minecraft', 'ice-physics', 10, 120, 'Why do boats behave differently on ice compared to packed ice or blue ice?', 'MultipleChoice', 'Different friction constants|Ice melts faster|Visual bug only|Speed cap differences', 'Different friction constants'),
('Minecraft', 'game-ticks', 7, 85, 'How often does Minecraft run game ticks per second?', 'FreeResponse', '', '20'),
('Minecraft', 'redstone-lag', 8, 95, 'Why do redstone clocks break or behave inconsistently under lag?', 'MultipleChoice', 'Redstone overheats|Timing is tick-based not time-based|Random bug|Player too far away', 'Timing is tick-based not time-based'),
('Minecraft', 'mob-spawning', 7, 90, 'For hostile mobs to spawn in Java Edition, light level must be at or below what?', 'FreeResponse', '', '0|zero'),
('Minecraft', 'mob-persistence-flags', 6, 70, 'What causes a mob to never despawn?', 'MultipleChoice', 'Being too old|Picking up items or being named|High difficulty|Player proximity', 'Picking up items or being named'),
('Minecraft', 'water-flow', 8, 100, 'Water flow length is determined by what algorithm?', 'MultipleChoice', 'Simple distance|Cost-based flood-fill pathfinding|Random direction|Always 8 blocks', 'Cost-based flood-fill pathfinding'),
('Minecraft', 'fall-damage-calc', 9, 110, 'Fall damage formula: damage equals (fall distance minus 3) divided by what?', 'FreeResponse', '', '2|two'),
('Minecraft', 'tnt-duping', 10, 130, 'TNT dupers exploit what technical flaw?', 'MultipleChoice', 'Random bug|Race condition between block updates and entity creation|Physics glitch|Memory leak', 'Race condition between block updates and entity creation'),
('Minecraft', 'raycast-mechanics', 9, 115, 'How does the game determine which block a player is looking at?', 'MultipleChoice', 'Raycast from eye position|Random selection|Closest block|Cursor position', 'Raycast from eye position'),
('Minecraft', 'ice-friction', 8, 95, 'Why do boats go faster on blue ice than regular ice?', 'MultipleChoice', 'Blue ice is magical|Different friction coefficients|Visual effect only|Temperature difference', 'Different friction coefficients'),
('Minecraft', 'chunk-loading', 7, 85, 'What happens to redstone when its chunk is unloaded?', 'MultipleChoice', 'Speeds up|Stops completely|Continues running|Becomes random', 'Stops completely');

-- BITCOIN/CRYPTO (Difficulty 4-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Bitcoin', 'blockchain-basics', 4, 50, 'What is a blockchain?', 'MultipleChoice', 'A type of currency|A distributed ledger|A mining tool|A wallet', 'A distributed ledger'),
('Bitcoin', 'mining-basics', 5, 60, 'What is Bitcoin mining?', 'MultipleChoice', 'Digging for coins|Verifying transactions via computation|Buying Bitcoin|Trading Bitcoin', 'Verifying transactions via computation'),
('Bitcoin', 'wallets', 5, 55, 'What stores your Bitcoin private keys?', 'MultipleChoice', 'Bank account|Wallet|Mining rig|Blockchain', 'Wallet'),
('Bitcoin', 'decentralization', 7, 80, 'What makes Bitcoin decentralized?', 'MultipleChoice', 'No single controlling authority|It is digital|It is encrypted|It is expensive', 'No single controlling authority'),
('Bitcoin', 'cryptography', 8, 90, 'What cryptographic function does Bitcoin primarily use?', 'MultipleChoice', 'MD5|SHA-256|AES|RSA', 'SHA-256'),
('Bitcoin', 'consensus', 9, 100, 'What consensus mechanism does Bitcoin use?', 'FreeResponse', '', 'proof of work|PoW');

-- WASHINGTON HISTORY (Difficulty 3-7)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('WashingtonHistory', 'statehood', 3, 40, 'Washington became a state in what year?', 'MultipleChoice', '1776|1889|1900|1950', '1889'),
('WashingtonHistory', 'geography', 4, 45, 'What is the capital of Washington state?', 'FreeResponse', '', 'Olympia'),
('WashingtonHistory', 'economy', 5, 60, 'Which major tech company is headquartered in Washington?', 'MultipleChoice', 'Apple|Microsoft|Google|Facebook', 'Microsoft'),
('WashingtonHistory', 'native-peoples', 6, 70, 'Which Native American tribe is prominent in the Puget Sound region?', 'MultipleChoice', 'Cherokee|Salish|Navajo|Sioux', 'Salish'),
('WashingtonHistory', 'landmarks', 5, 55, 'What famous landmark is located in Seattle?', 'MultipleChoice', 'Golden Gate Bridge|Space Needle|Statue of Liberty|Liberty Bell', 'Space Needle'),
('WashingtonHistory', 'industries', 7, 75, 'What industry was crucial to early Washington economy?', 'MultipleChoice', 'Cotton farming|Lumber/timber|Oil drilling|Gold mining', 'Lumber/timber');

-- WINPANTS (Winning at life: Dale Carnegie + Sun Tzu - Influencing people and strategic thinking)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('WinPants', 'carnegie-basics', 1, 20, 'According to Dale Carnegie, what is the sweetest sound to a person?', 'MultipleChoice', 'Music|Their own name|Praise|Silence', 'Their own name'),
('WinPants', 'influence-basics', 2, 30, 'What is the best way to win an argument according to Dale Carnegie?', 'MultipleChoice', 'Speak louder|Prove you are right|Avoid it|Use logic', 'Avoid it'),
('WinPants', 'sunzu-basics', 3, 40, 'Sun Tzu said: "The supreme art of war is to subdue the enemy without..."', 'FreeResponse', '', 'fighting|a fight|battle'),
('WinPants', 'listening-skill', 4, 50, 'Carnegie principle: To be interesting, you must first be...', 'FreeResponse', '', 'interested'),
('WinPants', 'criticism-handling', 5, 60, 'How does Carnegie recommend handling criticism of others?', 'MultipleChoice', 'Point out errors directly|Never criticize, condemn or complain|Criticize in public|Use sarcasm', 'Never criticize, condemn or complain'),
('WinPants', 'sunzu-positioning', 6, 70, 'Sun Tzu: "Victorious warriors win first, then..."', 'MultipleChoice', 'Fight|Attack|Go to war|Celebrate', 'Go to war'),
('WinPants', 'persuasion-advanced', 7, 80, 'Carnegie: The only way to get someone to do something is to make them...', 'FreeResponse', '', 'want to do it|want it');

-- EXPANSION SET: Additional questions across all domains (60+ new questions)

-- MORE MATH - Advanced and Varied (Difficulty 3-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Math', 'word-problems-basic', 3, 45, 'Tom has 12 apples. He gives 5 to Sarah and 3 to Mike. How many does he have left?', 'FreeResponse', '', '4'),
('Math', 'word-problems-basic', 3, 50, 'A book has 150 pages. If you read 30 pages per day, how many days to finish?', 'FreeResponse', '', '5'),
('Math', 'percents-advanced', 6, 70, 'A $40 item is on sale for 25% off. What is the sale price?', 'FreeResponse', '', '30|$30'),
('Math', 'percents-advanced', 6, 75, 'If a population of 200 increases by 15%, what is the new population?', 'FreeResponse', '', '230'),
('Math', 'angles', 5, 50, 'Two angles are complementary. If one angle is 35°, what is the other?', 'FreeResponse', '', '55'),
('Math', 'angles', 5, 50, 'Two angles are supplementary. If one is 120°, what is the other?', 'FreeResponse', '', '60'),
('Math', 'coordinate-geometry', 7, 80, 'What is the midpoint between (2,4) and (6,8)?', 'FreeResponse', '', '(4,6)|4,6'),
('Math', 'statistics-median', 7, 70, 'What is the median of: 3, 7, 2, 9, 5?', 'FreeResponse', '', '5'),
('Math', 'graph-theory', 9, 120, 'How many edges does a complete graph with 5 vertices have?', 'FreeResponse', '', '10'),
('Math', 'number-theory', 8, 90, 'What is the greatest common divisor (GCD) of 24 and 36?', 'FreeResponse', '', '12');

-- MORE SCIENCE - Diverse Topics (Difficulty 3-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Science', 'water-cycle', 3, 40, 'What process turns water from liquid to gas?', 'FreeResponse', '', 'evaporation'),
('Science', 'rocks-minerals', 4, 45, 'Which type of rock is formed from cooled lava?', 'MultipleChoice', 'Sedimentary|Igneous|Metamorphic|Limestone', 'Igneous'),
('Science', 'electricity', 5, 60, 'What is a complete path for electric current called?', 'FreeResponse', '', 'circuit'),
('Science', 'atoms', 6, 65, 'What is the center of an atom called?', 'FreeResponse', '', 'nucleus'),
('Science', 'waves', 7, 75, 'What type of wave requires a medium to travel?', 'MultipleChoice', 'Light wave|Radio wave|Mechanical wave|Electromagnetic wave', 'Mechanical wave'),
('Science', 'evolution', 8, 95, 'What process describes survival and reproduction of the best-adapted organisms?', 'FreeResponse', '', 'natural selection'),
('Science', 'thermodynamics', 9, 110, 'What law states that energy cannot be created or destroyed?', 'MultipleChoice', 'Newton First Law|First Law of Thermodynamics|Law of Gravity|Einstein Relativity', 'First Law of Thermodynamics'),
('Science', 'quantum-mechanics', 10, 140, 'What principle states you cannot know both position and momentum exactly?', 'FreeResponse', '', 'uncertainty principle|Heisenberg');

-- MORE READING - Comprehensive (Difficulty 2-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Reading', 'alphabetizing', 2, 30, 'Which word comes first alphabetically?', 'MultipleChoice', 'Zebra|Apple|Monkey|Dog', 'Apple'),
('Reading', 'contractions', 3, 35, 'What is the contraction for "do not"?', 'FreeResponse', '', 'don''t'),
('Reading', 'antonyms', 4, 40, 'What is the antonym of "difficult"?', 'MultipleChoice', 'Hard|Easy|Tough|Challenging', 'Easy'),
('Reading', 'homophones', 5, 50, 'Which word is a homophone of "write"?', 'MultipleChoice', 'Wrong|Right|Wright|Rite', 'Right'),
('Reading', 'roots-prefixes', 6, 60, 'The prefix "un-" means:', 'MultipleChoice', 'Before|After|Not|Very', 'Not'),
('Reading', 'point-of-view', 7, 75, 'A story told using "I" and "me" uses which point of view?', 'MultipleChoice', 'First person|Second person|Third person|Omniscient', 'First person'),
('Reading', 'rhetoric', 8, 90, 'Using emotional appeal in an argument is called:', 'FreeResponse', '', 'pathos'),
('Reading', 'literary-criticism', 9, 110, 'Analyzing a text through economic/class perspective is:', 'MultipleChoice', 'Feminist criticism|Marxist criticism|New criticism|Psychoanalytic criticism', 'Marxist criticism');

-- MORE LOGIC - Various Complexity (Difficulty 3-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Logic', 'venn-diagrams', 4, 55, 'In a Venn diagram, the overlapping section represents:', 'MultipleChoice', 'Nothing|Union|Intersection|Complement', 'Intersection'),
('Logic', 'syllogisms', 6, 75, 'All dogs are animals. All animals need food. Therefore, all dogs:', 'MultipleChoice', 'Are cats|Need food|Can fly|Are plants', 'Need food'),
('Logic', 'probability-logic', 7, 85, 'If P(A) = 0.3 and P(B) = 0.5, and A and B are independent, what is P(A and B)?', 'FreeResponse', '', '0.15|15%'),
('Logic', 'boolean-algebra', 8, 95, 'Simplify: A OR (A AND B)', 'FreeResponse', '', 'A'),
('Logic', 'propositional-logic', 9, 115, 'What is the contrapositive of: If P then Q?', 'MultipleChoice', 'If Q then P|If not Q then not P|If not P then not Q|Not valid', 'If not Q then not P'),
('Logic', 'formal-systems', 10, 130, 'In formal logic, what is a tautology?', 'MultipleChoice', 'Always false statement|Always true statement|Sometimes true|Paradox', 'Always true statement');

-- MORE HEALTH - Comprehensive (Difficulty 2-8)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Health', 'sleep', 2, 30, 'How many hours of sleep do elementary students need per night?', 'MultipleChoice', '5-6 hours|7-8 hours|9-11 hours|12+ hours', '9-11 hours'),
('Health', 'hydration', 3, 35, 'Which drink is best for staying hydrated during exercise?', 'MultipleChoice', 'Soda|Water|Energy drink|Coffee', 'Water'),
('Health', 'food-groups', 4, 45, 'Which nutrient is the main source of energy for the body?', 'MultipleChoice', 'Protein|Vitamins|Carbohydrates|Minerals', 'Carbohydrates'),
('Health', 'disease-prevention', 5, 60, 'What is the best way to prevent spreading germs?', 'MultipleChoice', 'Wearing gloves always|Washing hands regularly|Avoiding people|Taking antibiotics', 'Washing hands regularly'),
('Health', 'respiratory-system', 6, 70, 'Which organ is primarily responsible for gas exchange in the body?', 'FreeResponse', '', 'lungs'),
('Health', 'nutrition-advanced', 7, 80, 'What are the three macronutrients?', 'MultipleChoice', 'Vitamins, minerals, water|Carbs, proteins, fats|Fiber, sugar, salt|A, B, C vitamins', 'Carbs, proteins, fats'),
('Health', 'immune-system', 8, 95, 'What type of cells fight infections in your body?', 'MultipleChoice', 'Red blood cells|White blood cells|Platelets|Plasma', 'White blood cells');

-- MORE MINECRAFT - Advanced Gameplay (Difficulty 2-8)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Minecraft', 'smelting', 2, 30, 'What do you need to smelt iron ore?', 'MultipleChoice', 'Crafting table|Furnace|Anvil|Brewing stand', 'Furnace'),
('Minecraft', 'farming', 3, 40, 'What do you need to grow wheat?', 'MultipleChoice', 'Seeds and water nearby|Just seeds|Just water|Torches', 'Seeds and water nearby'),
('Minecraft', 'nether', 4, 55, 'What material do you need to build a Nether portal?', 'FreeResponse', '', 'obsidian'),
('Minecraft', 'potions', 6, 75, 'What is the base ingredient for all potions?', 'FreeResponse', '', 'nether wart'),
('Minecraft', 'command-blocks', 7, 85, 'What game mode allows you to fly and access all items?', 'FreeResponse', '', 'creative'),
('Minecraft', 'technical-mechanics', 8, 100, 'What is the maximum light level in Minecraft?', 'FreeResponse', '', '15');

-- MORE BITCOIN - Advanced Concepts (Difficulty 5-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('Bitcoin', 'halving', 6, 70, 'What happens during a Bitcoin halving?', 'MultipleChoice', 'Price cuts in half|Mining reward cuts in half|Number of coins cuts in half|Transaction speed doubles', 'Mining reward cuts in half'),
('Bitcoin', 'maximum-supply', 5, 55, 'What is the maximum number of Bitcoin that will ever exist?', 'MultipleChoice', '10 million|21 million|100 million|Unlimited', '21 million'),
('Bitcoin', 'transactions', 7, 85, 'What confirms Bitcoin transactions?', 'MultipleChoice', 'Banks|Miners|Government|Bitcoin company', 'Miners'),
('Bitcoin', 'public-key', 8, 95, 'What can others use your public key for?', 'MultipleChoice', 'Steal your coins|Send you coins|Access your wallet|Delete your account', 'Send you coins'),
('Bitcoin', 'smart-contracts', 9, 110, 'Which cryptocurrency platform is primarily known for smart contracts?', 'MultipleChoice', 'Bitcoin|Ethereum|Litecoin|Dogecoin', 'Ethereum'),
('Bitcoin', 'lightning-network', 10, 130, 'What is the Lightning Network designed to improve?', 'MultipleChoice', 'Security|Decentralization|Transaction speed and scalability|Mining efficiency', 'Transaction speed and scalability');

-- MORE WASHINGTON HISTORY - Comprehensive (Difficulty 3-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('WashingtonHistory', 'mt-rainier', 3, 40, 'What is Washington state''s highest peak?', 'FreeResponse', '', 'Mount Rainier|Mt Rainier'),
('WashingtonHistory', 'seattle-founding', 5, 60, 'Seattle is named after a chief of which Native American tribe?', 'MultipleChoice', 'Cherokee|Suquamish|Navajo|Apache', 'Suquamish'),
('WashingtonHistory', 'boeing', 6, 70, 'What major aerospace company was founded in Washington?', 'FreeResponse', '', 'Boeing'),
('WashingtonHistory', 'agriculture', 5, 55, 'Washington is the top US producer of which fruit?', 'MultipleChoice', 'Oranges|Apples|Bananas|Grapes', 'Apples'),
('WashingtonHistory', 'geology', 7, 85, 'What volcanic mountain erupted in Washington in 1980?', 'FreeResponse', '', 'Mount St Helens|Mt St Helens'),
('WashingtonHistory', 'pacific-northwest', 8, 95, 'What ecosystem dominates western Washington?', 'MultipleChoice', 'Desert|Temperate rainforest|Tundra|Savanna', 'Temperate rainforest'),
('WashingtonHistory', 'lewis-clark', 9, 110, 'The Lewis and Clark expedition reached the Pacific via what Washington river?', 'FreeResponse', '', 'Columbia|Columbia River');

-- ADDITIONAL WASHINGTON HISTORY - Extended Coverage (20 new questions, Difficulty 2-9)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('WashingtonHistory', 'state-symbols', 2, 30, 'What is Washington''s state flower?', 'MultipleChoice', 'Rose|Tulip|Coast Rhododendron|Daisy', 'Coast Rhododendron'),
('WashingtonHistory', 'geography-basic', 3, 35, 'What ocean borders Washington to the west?', 'FreeResponse', '', 'Pacific|Pacific Ocean'),
('WashingtonHistory', 'cities', 3, 40, 'What is the largest city in Washington by population?', 'FreeResponse', '', 'Seattle'),
('WashingtonHistory', 'cascade-range', 4, 50, 'What major mountain range runs through Washington?', 'MultipleChoice', 'Rocky Mountains|Cascade Range|Appalachian Mountains|Sierra Nevada', 'Cascade Range'),
('WashingtonHistory', 'puget-sound', 4, 55, 'What is the large inlet of the Pacific Ocean in northwest Washington called?', 'FreeResponse', '', 'Puget Sound'),
('WashingtonHistory', 'world-fairs', 5, 65, 'In what year did Seattle host the World''s Fair (Century 21 Exposition)?', 'MultipleChoice', '1950|1962|1974|1982', '1962'),
('WashingtonHistory', 'national-parks', 5, 60, 'Which national park in Washington contains temperate rainforest?', 'MultipleChoice', 'Yellowstone|Olympic|Yosemite|Grand Canyon', 'Olympic'),
('WashingtonHistory', 'dams', 6, 70, 'What is the largest concrete dam in North America, located in Washington?', 'MultipleChoice', 'Hoover Dam|Grand Coulee Dam|Glen Canyon Dam|Shasta Dam', 'Grand Coulee Dam'),
('WashingtonHistory', 'economy-tech', 6, 75, 'Besides Microsoft, which other major tech company has headquarters in Washington?', 'MultipleChoice', 'Google|Apple|Amazon|Facebook', 'Amazon'),
('WashingtonHistory', 'starbucks', 5, 55, 'In what Washington city was Starbucks founded?', 'FreeResponse', '', 'Seattle'),
('WashingtonHistory', 'territorial-period', 7, 80, 'Washington Territory was separated from what other territory in 1853?', 'MultipleChoice', 'California Territory|Oregon Territory|Idaho Territory|Montana Territory', 'Oregon Territory'),
('WashingtonHistory', 'spokane', 4, 50, 'What is the largest city in eastern Washington?', 'FreeResponse', '', 'Spokane'),
('WashingtonHistory', 'islands', 5, 60, 'What island group in Puget Sound is popular for tourism?', 'MultipleChoice', 'Hawaiian Islands|San Juan Islands|Channel Islands|Florida Keys', 'San Juan Islands'),
('WashingtonHistory', 'fishing-industry', 6, 70, 'What fish is crucial to Washington''s fishing industry and Native American culture?', 'FreeResponse', '', 'salmon'),
('WashingtonHistory', 'military-bases', 6, 75, 'What major naval base is located near Seattle?', 'MultipleChoice', 'Pearl Harbor|Naval Base Kitsap|Norfolk Naval Base|San Diego Naval Base', 'Naval Base Kitsap'),
('WashingtonHistory', 'bridges', 7, 85, 'What is the name of the famous floating bridge across Lake Washington?', 'MultipleChoice', 'Golden Gate|I-90 Bridge|Brooklyn Bridge|Bay Bridge', 'I-90 Bridge'),
('WashingtonHistory', 'gold-rush', 7, 80, 'Washington served as a gateway to which late 1800s gold rush?', 'MultipleChoice', 'California Gold Rush|Klondike Gold Rush|Colorado Gold Rush|Black Hills Gold Rush', 'Klondike Gold Rush'),
('WashingtonHistory', 'universities', 5, 55, 'What is Washington''s largest public university?', 'FreeResponse', '', 'University of Washington|UW'),
('WashingtonHistory', 'railroads', 8, 95, 'Which railroad reached Seattle in 1893, connecting it to the rest of the nation?', 'MultipleChoice', 'Union Pacific|Great Northern Railway|Southern Pacific|Central Pacific', 'Great Northern Railway'),
('WashingtonHistory', 'treaty-conflicts', 9, 110, 'What 1850s treaty forced many Native tribes to cede lands, leading to conflicts?', 'MultipleChoice', 'Treaty of Paris|Medicine Creek Treaty|Treaty of Guadalupe|Treaty of Ghent', 'Medicine Creek Treaty'),
('WashingtonHistory', 'sammamish-tribe', 4, 50, 'What does the Native American name "Sammamish" mean?', 'MultipleChoice', 'Big river|Hunter people|Mountain lake|Trading place', 'Hunter people'),
('WashingtonHistory', 'sammamish-incorporation', 5, 60, 'In what year did Sammamish officially become an incorporated city?', 'FreeResponse', '', '1999'),
('WashingtonHistory', 'sammamish-status', 4, 55, 'What was Sammamish before becoming a city in 1999?', 'MultipleChoice', 'Part of Seattle|Unincorporated area of King County|Part of Bellevue|Independent territory', 'Unincorporated area of King County'),
('WashingtonHistory', 'sammamish-incorporation-reason', 6, 75, 'Why did Sammamish residents seek incorporation as a city?', 'MultipleChoice', 'Lower taxes|Local control over zoning and development|State requirement|Federal mandate', 'Local control over zoning and development'),
('WashingtonHistory', 'sammamish-logging', 5, 65, 'What industry dominated Sammamish in the late 1800s and early 1900s?', 'FreeResponse', '', 'logging|timber'),
('WashingtonHistory', 'sammamish-plateau-development', 6, 80, 'Why was the Sammamish Plateau developed later than nearby cities like Bellevue?', 'MultipleChoice', 'Native American resistance|Lack of transportation infrastructure and utilities|Too mountainous|Federal restrictions', 'Lack of transportation infrastructure and utilities'),
('WashingtonHistory', 'sammamish-highways', 6, 70, 'What transportation improvements helped accelerate Sammamish''s growth in the late 20th century?', 'MultipleChoice', 'Monorail|Light rail|Interstate 90 and SR 520|Ferries', 'Interstate 90 and SR 520'),
('WashingtonHistory', 'sammamish-planned-communities', 5, 65, 'What planned community helped fuel population growth in Sammamish?', 'FreeResponse', '', 'Sahalee'),
('WashingtonHistory', 'lake-sammamish-settlement', 5, 60, 'How did Lake Sammamish influence early settlement patterns?', 'MultipleChoice', 'Provided gold|Supported transportation, fishing, and recreation|Military defense|Mining operations', 'Supported transportation, fishing, and recreation'),
('WashingtonHistory', 'sammamish-growth-approach', 7, 85, 'How has Sammamish approached growth since incorporation?', 'MultipleChoice', 'High-density urban development|Low-density residential zoning and environmental protection|Industrial focus|No restrictions', 'Low-density residential zoning and environmental protection'),
('WashingtonHistory', 'bellevue-name', 3, 40, 'Which nearby city''s name comes from French meaning "beautiful view"?', 'FreeResponse', '', 'Bellevue'),
('WashingtonHistory', 'redmond-microsoft', 4, 50, 'Which city near Sammamish is known worldwide as the longtime headquarters of Microsoft?', 'FreeResponse', '', 'Redmond'),
('WashingtonHistory', 'issaquah-mining', 5, 60, 'Which city at the base of the Issaquah Alps was historically known for coal mining?', 'FreeResponse', '', 'Issaquah'),
('WashingtonHistory', 'kirkland-costco', 4, 55, 'Which lakeside city was once the original headquarters of Costco?', 'FreeResponse', '', 'Kirkland'),
('WashingtonHistory', 'woodinville-wineries', 4, 50, 'Which city near Sammamish is famous for wineries, breweries, and distilleries?', 'FreeResponse', '', 'Woodinville'),
('WashingtonHistory', 'bothell-river', 5, 65, 'Which nearby city sits on the Sammamish River and was historically a logging and mill town?', 'FreeResponse', '', 'Bothell'),
('WashingtonHistory', 'renton-boeing', 5, 60, 'Which city south of Sammamish is home to Boeing''s 737 assembly plant?', 'FreeResponse', '', 'Renton'),
('WashingtonHistory', 'newcastle-coal', 5, 60, 'Which small city near Sammamish was originally founded as a coal mining town?', 'FreeResponse', '', 'Newcastle'),
('WashingtonHistory', 'mercer-island-bridges', 4, 55, 'Which city is located on an island in Lake Washington and connected to Seattle by floating bridges?', 'FreeResponse', '', 'Mercer Island'),
('WashingtonHistory', 'snoqualmie-waterfall', 4, 50, 'Which nearby city is best known for its historic waterfall and early hydroelectric power generation?', 'FreeResponse', '', 'Snoqualmie');

-- MORE WINPANTS - Advanced Strategic Thinking (Difficulty 3-10)
INSERT INTO Problems (Domain, MicroTopic, Difficulty, TargetTime, Question, Format, Options, CorrectAnswers) VALUES
('WinPants', 'admitting-wrong', 3, 45, 'Carnegie: If you are wrong, admit it quickly and...', 'FreeResponse', '', 'emphatically'),
('WinPants', 'genuine-interest', 4, 50, 'You can make more friends in two months by being interested in them than in two years by...', 'MultipleChoice', 'Being smart|Being rich|Trying to get them interested in you|Being funny', 'Trying to get them interested in you'),
('WinPants', 'sunzu-knowledge', 5, 65, 'Sun Tzu: "Know your enemy and know yourself and you will not be imperiled in..."', 'MultipleChoice', 'Ten battles|A hundred battles|A thousand battles|Any battle', 'A hundred battles'),
('WinPants', 'smile-power', 3, 40, 'According to Carnegie, what simple action is worth a million dollars?', 'MultipleChoice', 'A handshake|A smile|Eye contact|A compliment', 'A smile'),
('WinPants', 'sunzu-deception', 6, 75, 'Sun Tzu: "All warfare is based on..."', 'FreeResponse', '', 'deception'),
('WinPants', 'winning-cooperation', 7, 85, 'Carnegie: The only way on earth to influence people is to talk about what...', 'MultipleChoice', 'You want|They want|Is logical|Is fair', 'They want'),
('WinPants', 'sunzu-timing', 8, 95, 'Sun Tzu: "Opportunities multiply as they are..."', 'FreeResponse', '', 'seized'),
('WinPants', 'appreciation-power', 6, 70, 'What did Carnegie identify as the deepest craving in human nature?', 'MultipleChoice', 'Love|Money|The desire to be important|Security', 'The desire to be important'),
('WinPants', 'sunzu-preparation', 9, 110, 'Sun Tzu: "The general who wins makes many calculations before..."', 'MultipleChoice', 'The battle|The attack|The war|Victory', 'The battle'),
('WinPants', 'influence-mastery', 10, 120, 'Carnegie''s three C''s principle: Don''t criticize, condemn, or...', 'FreeResponse', '', 'complain'),
('WinPants', 'elephant-metaphor', 1, 25, 'How do you eat an elephant?', 'MultipleChoice', 'All at once|One bite at a time|Don''t eat it|Share it with others', 'One bite at a time'),
('WinPants', 'responsibility-level', 2, 30, 'Taking 100% responsibility means blaming yourself for everything.', 'MultipleChoice', 'True|False', 'False'),
('WinPants', 'results-vs-reasons', 3, 40, 'What matters more in achieving goals?', 'MultipleChoice', 'Good reasons why you can''t|Results you create|Intentions|Trying hard', 'Results you create'),
('WinPants', 'bold-action', 4, 45, 'What should you do when fear shows up while pursuing a goal?', 'MultipleChoice', 'Wait until fear goes away|Act despite the fear|Quit the goal|Analyze the fear', 'Act despite the fear'),
('WinPants', 'compassion-boldness', 5, 55, 'Effective leadership requires both compassion and...', 'FreeResponse', '', 'boldness'),
('WinPants', 'daily-actions', 3, 40, 'Large goals are achieved by taking what kind of actions?', 'MultipleChoice', 'Perfect actions|Daily small actions|Monthly big actions|Yearly reviews', 'Daily small actions'),
('WinPants', 'possibility-living', 6, 65, 'Living in possibility means focusing on what?', 'MultipleChoice', 'What might go wrong|What you can''t control|What could be created|Past failures', 'What could be created'),
('WinPants', 'commitment-power', 7, 75, 'True commitment is shown by...', 'MultipleChoice', 'Saying you''ll try|Having good intentions|Taking action no matter what|Waiting for motivation', 'Taking action no matter what'),
('WinPants', 'breakthrough-from-breakdown', 8, 85, 'Breakdowns are opportunities to create...', 'FreeResponse', '', 'breakthroughs'),
('WinPants', 'intention-creation', 5, 60, 'Results are created by conscious intention, not by...', 'MultipleChoice', 'Hard work|Accident or default|Planning|Persistence', 'Accident or default'),
('WinPants', 'being-vs-doing', 7, 80, 'Who you are being determines what you will be...', 'FreeResponse', '', 'doing|having'),
('WinPants', 'ask-for-wants', 4, 50, 'To get what you want, you must first...', 'MultipleChoice', 'Deserve it|Wait for it|Ask for it|Earn it', 'Ask for it'),
('WinPants', 'limiting-beliefs', 6, 70, 'What stops most people from achieving their dreams?', 'MultipleChoice', 'Lack of resources|Limiting beliefs|Bad luck|Other people', 'Limiting beliefs'),
('WinPants', 'service-leadership', 8, 90, 'The most powerful leadership comes from a place of...', 'FreeResponse', '', 'service'),
('WinPants', 'completion-integrity', 9, 100, 'Incomplete projects drain your energy and compromise your...', 'FreeResponse', '', 'integrity'),
('WinPants', 'control-focus', 5, 55, 'Where should you focus your energy?', 'MultipleChoice', 'Things you can''t control|What others think|Things you can control|Past mistakes', 'Things you can control'),
('WinPants', 'value-creation', 7, 75, 'Success comes from creating value for...', 'MultipleChoice', 'Yourself first|Others|Your boss|Everyone equally', 'Others'),
('WinPants', 'declaration-power', 9, 105, 'A declaration is more powerful than a goal because it creates...', 'MultipleChoice', 'Hope|A new reality|Pressure|Expectations', 'A new reality'),
('WinPants', 'anxiety-reduction', 4, 50, 'Breaking big goals into small steps primarily reduces...', 'MultipleChoice', 'Time needed|Anxiety and overwhelm|Competition|Uncertainty', 'Anxiety and overwhelm'),
('WinPants', 'hundred-percent', 10, 115, 'Taking 100% responsibility means owning your power to...', 'MultipleChoice', 'Blame yourself|Control everything|Create your results|Avoid mistakes', 'Create your results'),
('WinPants', 'phelps-limits', 2, 35, 'What happens the more you dream?', 'MultipleChoice', 'The more disappointed you get|The farther you get|The more you sleep|The harder it becomes', 'The farther you get'),
('WinPants', 'extra-mile', 5, 60, 'To be the best, you must do things that...', 'MultipleChoice', 'Everyone does|Are easy|Other people aren''t willing to do|Look impressive', 'Other people aren''t willing to do'),
('WinPants', 'impossible-imagination', 4, 55, 'What makes the "impossible" possible?', 'MultipleChoice', 'Luck|Imagination|Money|Talent alone', 'Imagination'),
('WinPants', 'uncomfortable-growth', 6, 70, 'Goals should force you to work even if they are...', 'FreeResponse', '', 'uncomfortable'),
('WinPants', 'no-limits', 3, 45, 'You can''t put a limit on...', 'FreeResponse', '', 'anything'),
('WinPants', 'willing-to-do', 7, 80, 'Excellence requires doing what others are not...', 'FreeResponse', '', 'willing to do'),
('WinPants', 'dream-distance', 5, 65, 'Your dreams determine how far you...', 'MultipleChoice', 'Fall|Get|Try|Wait', 'Get'),
('WinPants', 'easy-goals', 4, 50, 'Should goals be easy?', 'MultipleChoice', 'Yes, to avoid failure|No, they should force you to work|Yes, to build confidence|Depends on mood', 'No, they should force you to work');